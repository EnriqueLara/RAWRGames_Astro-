using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item2_0
{
    //public string Name;
    public ItemStructs2_0.ItemInfo itemInfo;
    public bool showAllInfo;
    //materials
    //equipment
    public EquipmentStructs.EquipmentType equipmentType;
    public EquipmentStructs.EquipmentStats equipmentStats;
    public EquipmentStructs.EquipmentPrefabs equipmentPrefab;
    //weapon
    public WeaponStructs2_0.WeaponStats weaponStats;
    public WeaponStructs2_0.WeaponPrefabs weaponPrefabs;


    public bool showCraftingMaterials;
    public int numOfReqObj;
    public Vector2[] requiredObjs;
    public ItemStructs2_0.ItemUnityFields itemUnityFields;

    //Editor
    public Vector2 scrollPos;
}
