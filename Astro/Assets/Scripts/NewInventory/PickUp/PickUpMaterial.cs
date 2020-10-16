using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMaterial : MonoBehaviour
{
    [SerializeField] ItemDatabase2_0 itemDb;
    [SerializeField] bool harvestMaterial;
    [SerializeField] Harvest harvest;
    [SerializeField] int materialId;
    string materialID;
    [SerializeField] private InventoryItem2_0 item = new InventoryItem2_0();




    private void Start()
    {
        //set the item information from the database
        materialID = "M-" + materialId.ToString();

        item.inventoryItemInfo.itemId = materialID;
        item.inventoryItemInfo.itemType = ItemEnums2_0.ItemType.Material;
        item.inventoryItemInfo.itemName = itemDb.GetItemWithKey(item.inventoryItemInfo.itemId).itemInfo.itemName;
        item.inventoryItemInfo.itemRarity = itemDb.GetItemWithKey(item.inventoryItemInfo.itemId).itemInfo.itemRarity;
        item.inventoryItemInfo.itemDescription = itemDb.GetItemWithKey(item.inventoryItemInfo.itemId).itemInfo.itemDescription;


        //if(harvest)
        harvest.setItem(item);
    }


}
