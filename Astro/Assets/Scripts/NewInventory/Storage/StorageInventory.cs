using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageInventory : MonoBehaviour
{
    public ItemDatabase2_0 itemDB;
    public Dictionary<int, InventoryItem2_0> inventory = new Dictionary<int, InventoryItem2_0>(); //el primero es el id del slot y el segundo el item 
    public Dictionary<string, int> materials = new Dictionary<string, int>();//Id, cantidad de items con ese id

    public int numOfSlots;
    public GameObject slotPrefab;
    public GameObject slotContainer;
    public int inventoryCount;

    private void Start()
    {

    }

    private void Update()
    {
        inventoryCount = inventory.Count;
    }
    private void UpdateDatabaseDictionary()
    {

    }
    public void AddItem(int _slotID, InventoryItem2_0 _item)
    {
        inventory.Add(_slotID, _item);
    }
    public void RemoveItem(int _slotId)
    {
        inventory.Remove(_slotId);
    }
    public string GetItemId(int _slot)
    {
        return inventory[_slot].inventoryItemInfo.itemId;
    }
    public bool IsSlotEmpty(int _slotNum)
    {
        return !inventory.ContainsKey(_slotNum);
    }
}
