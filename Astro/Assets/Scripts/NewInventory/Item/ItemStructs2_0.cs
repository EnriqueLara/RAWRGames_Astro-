using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemEnums2_0;

public class ItemStructs2_0 : MonoBehaviour
{
    [System.Serializable]
    public struct ItemInfo
    {
        public string itemId;
        public string itemName;
        public ItemEnums2_0.ItemType itemType;
        public ItemEnums2_0.ItemRarity itemRarity;
        public string itemDescription;
    }
    [System.Serializable]
    public struct ItemUnityFields
    {
        public Sprite itemIcon;
        public GameObject itemDropPrefab;
    }
}
