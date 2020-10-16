using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentStructs : MonoBehaviour
{
    [System.Serializable]
    public struct EquipmentStats
    {
        public int equipmentLevel;
        public float equipmentDurability;
        public float equipmentHealth;
        public float equipmentArmor;

        public float equipmentOxygenUse;
        public float equipmentMovementSpeed;
    }
    [System.Serializable]
    public struct EquipmentPrefabs
    {
        public GameObject prefab;
    }

    public enum EquipmentType
    {
        Null,
        Helmet,
        Chest,
        Gloves,
        Legs,
        Boots
    }
}
