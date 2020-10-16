using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private SlotManager2_0 slotManager;    
    [SerializeField] private InventoryItem2_0 item = new InventoryItem2_0();
    private void Start()
    {
        //slotManager = FindObjectOfType<SlotManager2_0>();
        slotManager = GameManager.instance.personalInventoryManager.slotManager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(slotManager.AreEmptySlots())
            {
                slotManager.AddItem(item.inventoryItemInfo.itemId,item);
                Destroy(gameObject);
            }
        }
    }
    public void setItem(InventoryItem2_0 _item)
    {
        //item = _item;  ESTO HACE QUE SEA POR REFERENCIA Y NO POR VALOR, HAY QUE ASIGNAR CADA UNO DE LOS STRUCTS
        item.inventoryItemInfo = _item.inventoryItemInfo;
        item.equipmentType = _item.equipmentType;
        item.equipmentStats = _item.equipmentStats;
        item.weaponStats = _item.weaponStats;
    }
    public void SetSlotManager(SlotManager2_0 _sM)
    {
        slotManager = _sM;
    }
}
