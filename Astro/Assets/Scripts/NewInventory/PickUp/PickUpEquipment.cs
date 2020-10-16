using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEquipment : MonoBehaviour
{
    [SerializeField] ItemDatabase2_0 itemDb;
    [SerializeField] Harvest harvest;
    [SerializeField] PickUp pickUp;
    [SerializeField] int equipmentId;
    string ID;
    [SerializeField] InventoryItem2_0 item = new InventoryItem2_0();



    private void Start()
    {

        ID = "E-" + equipmentId.ToString();

        if(item.inventoryItemInfo.itemId == "")
        {
            //When you drop the item the slotmanager2_0 script assigns the item id so theres no need to assign it again
            item.inventoryItemInfo.itemId = ID;
        }
        item.inventoryItemInfo.itemName = itemDb.GetItemWithKey(item.inventoryItemInfo.itemId).itemInfo.itemName;
        item.inventoryItemInfo.itemRarity = itemDb.GetItemWithKey(item.inventoryItemInfo.itemId).itemInfo.itemRarity;
        item.inventoryItemInfo.itemDescription = itemDb.GetItemWithKey(item.inventoryItemInfo.itemId).itemInfo.itemDescription;
        item.equipmentType = itemDb.GetItemWithKey(item.inventoryItemInfo.itemId).equipmentType;
        item.inventoryItemInfo.itemType = ItemEnums2_0.ItemType.Equipment;

        if(harvest)
            harvest.setItem(item);
        if (pickUp)
            pickUp.setItem(item);
    }
    public void SetItem(InventoryItem2_0 _item)
    {
        item.inventoryItemInfo = _item.inventoryItemInfo;
        item.equipmentStats = _item.equipmentStats;
        item.equipmentType = _item.equipmentType;
    }
}
