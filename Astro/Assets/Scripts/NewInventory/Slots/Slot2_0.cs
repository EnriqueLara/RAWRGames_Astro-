using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot2_0 : MonoBehaviour
{
    public int slotID;
    public bool isEmpty;
    public Image iconImage;
    public Sprite itemIcon;
    public GameObject itemDropPrefab;
    public SlotManager2_0 slotManager;
    public Button button;
    public GameObject itemSelectedImage;

    [Header("Item")]
    public string itemID;
    

    public InventoryItem2_0 item;

    void Start()
    {
        itemSelectedImage.SetActive(false);
    }

    public void SetDropItemId()
    {
        slotManager.slots[slotManager.selectedSlotId].GetComponent<Slot2_0>().itemSelectedImage.SetActive(false);
        slotManager.selectedSlotId = slotID;
        itemSelectedImage.SetActive(true);
        Debug.Log(slotID);
    }
    public void SetIsEmpty(bool _bool)
    {
        isEmpty = _bool;
        button.interactable = !_bool;
    }

}
