using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{

    [SerializeField] ItemDatabase2_0 itemDb;
    [SerializeField] Harvest harvest;
    [SerializeField] PickUp pickUp;
    [SerializeField] int materialId;
    [SerializeField] WeaponStructs2_0.WeaponStats wStats;
    string materialID;
    private InventoryItem2_0 item = new InventoryItem2_0();



    private void Start()
    {
        materialID = "W-" + materialId.ToString();

        item.inventoryItemInfo.itemId = materialID;
        item.inventoryItemInfo.itemType = ItemEnums2_0.ItemType.Weapon;

        item.inventoryItemInfo.itemName = itemDb.GetItemWithKey(item.inventoryItemInfo.itemId).itemInfo.itemName;
        item.inventoryItemInfo.itemRarity = itemDb.GetItemWithKey(item.inventoryItemInfo.itemId).itemInfo.itemRarity;
        item.inventoryItemInfo.itemDescription = itemDb.GetItemWithKey(item.inventoryItemInfo.itemId).itemInfo.itemDescription;

        item.weaponStats = wStats;

        if (harvest)
            harvest.setItem(item);
        if (pickUp)
            pickUp.setItem(item);
    }
    public void SetItem(InventoryItem2_0 _item)
    {
        item.inventoryItemInfo = _item.inventoryItemInfo;
        item.weaponStats = _item.weaponStats;
    }
}
