using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item Database2_0", menuName = "Inventory2_0/InventoryAndStorage")]
[System.Serializable]
public class StorageAndInventorySaveAndLoad : ScriptableObject
{

    public List<InventoryItem2_0> inventoryLists = new List<InventoryItem2_0>();

    public int prueba = 5;
    


    public void InventoryToList(Dictionary<int, InventoryItem2_0> _inventory)
    {
        inventoryLists.Clear();
        foreach(KeyValuePair<int, InventoryItem2_0> item in _inventory)
        {
            item.Value.savedSlotID = item.Key;
            inventoryLists.Add(item.Value);
        }
    }
}
