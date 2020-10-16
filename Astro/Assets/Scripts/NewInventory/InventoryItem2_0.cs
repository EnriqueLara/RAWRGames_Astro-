using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem2_0
{
    //all items
    public ItemStructs2_0.ItemInfo inventoryItemInfo;
    //only equipment
    public EquipmentStructs.EquipmentType equipmentType;
    public EquipmentStructs.EquipmentStats equipmentStats;
    //weaponstats
    public WeaponStructs2_0.WeaponStats weaponStats;

    public int savedSlotID;
}
