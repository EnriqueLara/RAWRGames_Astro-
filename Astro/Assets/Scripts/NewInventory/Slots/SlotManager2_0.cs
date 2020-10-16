using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemEnums2_0;

//This script must be in the inventory UI content
public class SlotManager2_0 : MonoBehaviour
{
    [SerializeField] SlotManager2_0 otherInventory;
    [SerializeField] StorageInventory sI;
    [SerializeField] bool isStorage;
    [SerializeField] ItemDatabase2_0 itemDb;
    public GameObject slotPrefab;
    public Slot2_0[] slots;
    private int numOfSlots;
    public int selectedSlotId;
    [SerializeField]
    private Transform placeToDrop;//para saber donde dropear el item

    private void Start()
    {
        SetNumOfSlots();
    }
    private void Update()
    {
        if(isStorage)
        {
            Debug.Log(selectedSlotId);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            UpdateInventoryUI();
        }
    }

    public void SetNumOfSlots()
    {
        if (GameManager.instance)
        {
            if(isStorage)
            {
                numOfSlots = sI.numOfSlots;
                //slots = new Slot2_0[sI.numOfSlots];
            }
            else
            {
                numOfSlots = GameManager.instance.personalInventoryManager.numOfSlots;
                //slots = new Slot2_0[GameManager.instance.personalInventoryManager.numOfSlots];
            }
            slots = new Slot2_0[numOfSlots];
            CreateSlots();
            UpdateInventoryUI();
        }
    }
    public void CreateSlots()
    {
        if (GameManager.instance)
        {
            for (int i = 0; i < numOfSlots; i++)
            {
                slots[i] = Instantiate(slotPrefab, transform).GetComponent<Slot2_0>();
                if(slots[i])
                {
                    slots[i].slotID = i;
                    slots[i].SetIsEmpty(true);
                    slots[i].slotManager = this;
                }
            }
        }
    }
    public void UpdateInventoryUI()
    {
        for (int i = 0; i < numOfSlots; i++)
        {
            if (!GameManager.instance.personalInventoryManager.IsSlotEmpty(i))
            {
                slots[i].SetIsEmpty(false);
                slots[i].itemID = GameManager.instance.personalInventoryManager.GetItemId(i);
                //look in item database for the icon and drop prefab 
                slots[i].itemIcon = itemDb.GetItemWithKey(GameManager.instance.personalInventoryManager.GetItemId(i)).itemUnityFields.itemIcon;
                slots[i].itemDropPrefab = itemDb.GetItemWithKey(GameManager.instance.personalInventoryManager.GetItemId(i)).itemUnityFields.itemDropPrefab;
                slots[i].iconImage.sprite = slots[i].itemIcon;
                slots[i].item = GameManager.instance.personalInventoryManager.GetItemInSlot(i);
            }

        }
    }

    public void AddItem(string _itemId, InventoryItem2_0 _item)
    {
        int emptySlotId = GetEmptySlotID();
        if (emptySlotId >= 0)
        {
            slots[emptySlotId].SetIsEmpty(false);
            slots[emptySlotId].itemID = _itemId;
            slots[emptySlotId].itemIcon = itemDb.GetItemWithKey(_itemId).itemUnityFields.itemIcon;
            slots[emptySlotId].itemDropPrefab = itemDb.GetItemWithKey(_itemId).itemUnityFields.itemDropPrefab;
            slots[emptySlotId].iconImage.sprite = slots[emptySlotId].itemIcon;

            slots[emptySlotId].item.inventoryItemInfo = _item.inventoryItemInfo;
            slots[emptySlotId].item.equipmentStats = _item.equipmentStats;
            slots[emptySlotId].item.equipmentType = _item.equipmentType;
            slots[emptySlotId].item.weaponStats = _item.weaponStats;
            GameManager.instance.personalInventoryManager.inventory.Add(emptySlotId, _item);
        }
    }
    public void AddItemToStorage(string _itemId, InventoryItem2_0 _item)
    {
        int emptySlotId = GetEmptySlotID();
        if (emptySlotId >= 0)
        {
            slots[emptySlotId].SetIsEmpty(false);
            slots[emptySlotId].itemID = _itemId;
            slots[emptySlotId].itemIcon = itemDb.GetItemWithKey(_itemId).itemUnityFields.itemIcon;
            slots[emptySlotId].itemDropPrefab = itemDb.GetItemWithKey(_itemId).itemUnityFields.itemDropPrefab;
            slots[emptySlotId].iconImage.sprite = slots[emptySlotId].itemIcon;

            slots[emptySlotId].item.inventoryItemInfo = _item.inventoryItemInfo;
            slots[emptySlotId].item.equipmentStats = _item.equipmentStats;
            slots[emptySlotId].item.equipmentType = _item.equipmentType;
            slots[emptySlotId].item.weaponStats = _item.weaponStats;

            sI.AddItem(emptySlotId, _item);
            //GameManager.instance.personalInventoryManager.inventory.Add(emptySlotId, _item);
        }
    }
    public int GetEmptySlotID()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isEmpty)
            {
                return slots[i].slotID;
            }
        }
        return -1;
        //no hay ningun espacio disponible
    }
    public bool AreEmptySlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isEmpty)
            {
                return true;
            }
        }
        return false;
        //no hay ningun espacio disponible
    }
    public void DropItem()
    {
        //check drop item type
        if(slots[selectedSlotId].item.inventoryItemInfo.itemType == ItemType.Material)
        {
            //drop
            if(DropMaterial())//if theres no item drop prefab it will not set slot as empty
            SetSlotToEmpty(selectedSlotId);
        }
        else if(slots[selectedSlotId].item.inventoryItemInfo.itemType == ItemType.Equipment)
        {
            //drop
            if (DropEquipment())//if theres no item drop prefab it will not set slot as empty
                SetSlotToEmpty(selectedSlotId);
        }
        else if (slots[selectedSlotId].item.inventoryItemInfo.itemType == ItemType.Weapon)
        {
            //drop
            if (DropWeapon())//if theres no item drop prefab it will not set slot as empty
                SetSlotToEmpty(selectedSlotId);
        }
        //remove from inventory
        Debug.Log("Eliminar del inventario");
        GameManager.instance.personalInventoryManager.RemoveItem(selectedSlotId);
        
    }
    public void SetSlotToEmpty(int _slotId)
    {
        slots[_slotId].SetIsEmpty(true);
        slots[_slotId].item = new InventoryItem2_0();
        //slots[dropItemId].itemID = "";
        slots[_slotId].itemIcon = null;
        slots[_slotId].iconImage.sprite = slots[selectedSlotId].itemIcon;
        slots[_slotId].itemSelectedImage.SetActive(false);
    }
    public bool DropMaterial()
    {
        string itemId = slots[selectedSlotId].item.inventoryItemInfo.itemId;
        PickUp pickUp = new PickUp();

        //instance prefab
        if(itemDb.GetItemWithKey(itemId).itemUnityFields.itemDropPrefab)
        {
            pickUp = Instantiate(itemDb.GetItemWithKey(itemId).itemUnityFields.itemDropPrefab, 
            new Vector3(placeToDrop.transform.position.x,
            placeToDrop.transform.position.y, placeToDrop.transform.position.z), Quaternion.identity).GetComponent<PickUp>();
        }
        else
        {
            Debug.LogError("This item has no item drop prefab");
            return false;
        }

        //set item to drop
        InventoryItem2_0 dropItem = new InventoryItem2_0();
        dropItem.inventoryItemInfo = slots[selectedSlotId].item.inventoryItemInfo;

        //set prefab
        pickUp.SetSlotManager(this);
        pickUp.setItem(dropItem);
        return true;

    }
    public bool DropEquipment()
    {
        string itemId = slots[selectedSlotId].item.inventoryItemInfo.itemId;
        PickUpEquipment pickUpE = new PickUpEquipment();
        PickUp pickUp = new PickUp();

        //instance prefab
        if (itemDb.GetItemWithKey(itemId).itemUnityFields.itemDropPrefab)
        {
            GameObject item = Instantiate(itemDb.GetItemWithKey(itemId).itemUnityFields.itemDropPrefab,
            new Vector3(placeToDrop.transform.position.x,
            placeToDrop.transform.position.y, placeToDrop.transform.position.z), Quaternion.identity);
            pickUp = item.GetComponent<PickUp>();
            pickUpE = item.GetComponent<PickUpEquipment>();
        }
        else
        {
            Debug.LogError("This item has no item drop prefab");
            return false;
        }

        //set item to drop
        InventoryItem2_0 dropItem = new InventoryItem2_0();
        dropItem.inventoryItemInfo = slots[selectedSlotId].item.inventoryItemInfo;
        dropItem.equipmentType = slots[selectedSlotId].item.equipmentType;

        //set prefab
        pickUp.SetSlotManager(this);
        pickUpE.SetItem(slots[selectedSlotId].item);
        return true;

    }
    public bool DropWeapon()
    {
        string itemId = slots[selectedSlotId].item.inventoryItemInfo.itemId;
        PickUpWeapon pickUpW = new PickUpWeapon();
        PickUp pickUp = new PickUp();

        //instance prefab
        if (itemDb.GetItemWithKey(itemId).itemUnityFields.itemDropPrefab)
        {
            GameObject item = Instantiate(itemDb.GetItemWithKey(itemId).itemUnityFields.itemDropPrefab,
            new Vector3(placeToDrop.transform.position.x,
            placeToDrop.transform.position.y, placeToDrop.transform.position.z), Quaternion.identity);
            pickUp = item.GetComponent<PickUp>();
            pickUpW = item.GetComponent<PickUpWeapon>();
        }
        else
        {
            Debug.LogError("This item has no item drop prefab");
            return false;
        }

        //set item to drop
        InventoryItem2_0 dropItem = new InventoryItem2_0();
        dropItem.inventoryItemInfo = slots[selectedSlotId].item.inventoryItemInfo;
        dropItem.equipmentType = slots[selectedSlotId].item.equipmentType;

        //set prefab
        pickUp.SetSlotManager(this);
        pickUpW.SetItem(slots[selectedSlotId].item);
        return true;

    }

    public void TransferTo(string _inventory)
    {
        InventoryItem2_0 transferedItem = new InventoryItem2_0();
        transferedItem.inventoryItemInfo = slots[selectedSlotId].item.inventoryItemInfo;
        transferedItem.equipmentType = slots[selectedSlotId].item.equipmentType;
        transferedItem.equipmentStats = slots[selectedSlotId].item.equipmentStats;
        transferedItem.weaponStats = slots[selectedSlotId].item.weaponStats;

        
        

        if (_inventory == "Personal")
        {
            otherInventory.AddItem(transferedItem.inventoryItemInfo.itemId, transferedItem);
            sI.RemoveItem(selectedSlotId);
        }
        

        if (_inventory == "Storage")
        {
            otherInventory.AddItemToStorage(transferedItem.inventoryItemInfo.itemId, transferedItem);
            GameManager.instance.personalInventoryManager.RemoveItem(selectedSlotId);
        }

        SetSlotToEmpty(selectedSlotId);
    }

}
