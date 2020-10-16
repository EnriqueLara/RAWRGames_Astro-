using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStructs2_0 : MonoBehaviour
{
    [System.Serializable]
    public struct WeaponStats
    {
        public int weaponLevel;
        public float weaponDurability;
        public float weaponMaxDurability;
        public float weaponDamage;
        public float weaponFireRate;
        public float weaponCritHitChance;
        public float weaponCritHitDamage;
        public float weaponBulletSpeed;
        public float weaponRange;
        public float weaponImpact;
    }

    [System.Serializable]
    public struct WeaponPrefabs
    {
        public GameObject weaponPrefab;
        public GameObject weaponProjectilePrefab;
    }
}
