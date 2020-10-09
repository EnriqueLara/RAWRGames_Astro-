
using UnityEngine;

public class WeaponStructs : MonoBehaviour
{
    [System.Serializable]
    public struct WeaponStats
    {
        public float damage;
        public float fireRate;
        public float criticalHitChance;
        public float criticalHitDamage;
        public float bulletSpeed;
        public float range;
        public float impact;

    }
    [System.Serializable]
    public struct WeaponPrefabs
    {
        public GameObject projectilePrefab;
        public GameObject weaponPrefab;

        
    }
    [System.Serializable]
    public struct WeaponInformation
    {
        public int ID;
        public string description;
        public WeaponEnums.WeaponRarity rarity;
        public int level;
        public int maxLevel;
    }
    [System.Serializable]
    public struct WeaponHiddenInfo
    {
        public WeaponEnums.WeaponState state;
    }
    [System.Serializable]
    public struct UnityFields
    {
        public Sprite Icon;
        public Sprite lockedIcon;
    }
}
