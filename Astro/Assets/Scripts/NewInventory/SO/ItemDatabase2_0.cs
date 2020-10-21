using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Database2_0", menuName = "Inventory2_0/Item DataBase")]
public class ItemDatabase2_0 : ScriptableObject
{
    public List<Item2_0> items;
    public Dictionary<string, Item2_0> databaseDictionary = new Dictionary<string, Item2_0>();

    public void UpdateDatabaseDictionary()
    {

    }
    public void InventoryToDictionary()
    {
        foreach (Item2_0 item in items)
        {
            databaseDictionary.Add(item.itemInfo.itemId, item);
            Debug.Log("ItemAdded:  " + item.itemInfo.itemId);
        }
    }
    public Item2_0 GetItemWithKey(string _itemId)
    {
        if(databaseDictionary.ContainsKey(_itemId))
        {
            return databaseDictionary[_itemId]; 

        }
        else
        {
            Debug.LogError("No se encontro el item con ID:" + _itemId);
        }
        return null;
    }



    //this functions are only for the editor, in runtime we need to use dictionaries 

    public Item2_0 FindMaterial(string _id)
    {
        foreach (Item2_0 item in items)
        {
            if (item.itemInfo.itemId == "M-" + _id)
            {
                return item;
            }
        }
        return null;
    }

    public Item2_0 FindEquipment(string _id)
    {
        foreach (Item2_0 item in items)
        {
            if (item.itemInfo.itemId == "E-" + _id)
            {
                return item;
            }
        }
        return null;
    }

    public Item2_0 FindWeapon(string _id)
    {
        foreach (Item2_0 item in items)
        {
            if (item.itemInfo.itemId == "W-" + _id)
            {
                return item;
            }
        }
        return null;
    }
    public Item2_0 FindModule(string _id)
    {
        foreach (Item2_0 item in items)
        {
            if (item.itemInfo.itemId == "LM-" + _id)
            {
                return item;
            }
        }
        return null;
    }
    public void DebugSomething(string _text)
    {
        Debug.Log(_text);
    }
}
