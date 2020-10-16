using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PersonalInventory : MonoBehaviour
{
    public Text text;
    public SlotManager2_0 slotManager;
    public StorageAndInventorySaveAndLoad inventories;

    [SerializeField]
    public Dictionary<int, InventoryItem2_0> inventory = new Dictionary<int, InventoryItem2_0>(); //el primero es el id del slot y el segundo el item 
    
    public ItemDatabase2_0 itemDB;

    public int numOfSlots;
    public GameObject slotPrefab;
    public GameObject slotContainer;
    public int inventoryCount;

    private void Start()
    {
        itemDB.InventoryToDictionary();

        //GameManager.instance.SyL.LoadWeaponList();
        //inventory = inventories.inventory;
        //inventoryCount = inventories.prueba;

    }

    private void Update()
    {

        text.text = inventories.prueba.ToString();
        
        inventoryCount = inventory.Count;
        //inventoryCount = inventories.inventory.Count;
        //test para guardar
        if(Input.GetKeyDown(KeyCode.P))
        {
            //inventories.SaveInventory(inventory);
            inventories.InventoryToList(inventory);
            //GameManager.instance.SyL.SaveWeaponList();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //inventories.SaveInventory(inventory);
            //GameManager.instance.SyL.LoadWeaponList();
            LoadListToDictionary(inventories.inventoryLists);
            slotManager.UpdateInventoryUI();
        }

    }
    public void LoadListToDictionary(List<InventoryItem2_0> _inventory)
    {
        foreach(InventoryItem2_0 item in _inventory)
        {
            inventory.Add(item.savedSlotID, item);
        }
    }


    public void AddItem(int _slotID, InventoryItem2_0 _item)
    {
        inventory.Add(_slotID,_item);
    }
    public void RemoveItem(int _slotId)
    {
        inventory.Remove(_slotId);
    }
    public string GetItemId(int _slot)
    {
        return inventory[_slot].inventoryItemInfo.itemId;
    }
    public InventoryItem2_0 GetItemInSlot(int _slot)
    {
        return inventory[_slot];
    }
    public bool IsSlotEmpty(int _slotNum)
    {
        return !inventory.ContainsKey(_slotNum);
    }
    public void addOne()
    {
        inventories.prueba++;
    }

}
