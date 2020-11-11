using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerStates;

public class Harvest : MonoBehaviour
{

    [SerializeField] float timeToHarvest;

    [SerializeField] GameObject progressBar;
    [SerializeField] Image progressImage;
    [SerializeField] SlotManager2_0 slotManager;

    private ResourceStats resourceInfo;

    private float time;
    private GameObject player;
    private bool isIn;

    [SerializeField] private InventoryItem2_0 item = new InventoryItem2_0();

    private void Start()
    {
        resourceInfo = GetComponent<ResourceStats>();
        item.inventoryItemInfo.itemId = resourceInfo.info.ID;
        progressBar.SetActive(false);
        //Time.timeScale = 1;
        slotManager = GameManager.instance.personalInventoryManager.slotManager;
    }
    void Update()
    {
        progressImage.fillAmount = GetProgress();
        if (time <= 0)
        {
            progressBar.SetActive(false);
        }
        else
        {
            progressBar.SetActive(true);
        }
        if (isIn)
        {

            if (player.GetComponent<PlayerStateMachine>().CheckIfCanHarvest())//&& slotManager.AreEmptySlots()
            {
                player.gameObject.GetComponent<PlayerStateMachine>().SetState(playerStates.Harvesting);
                player.gameObject.GetComponent<PlayerStateMachine>().SetHarvestingAnim();

                player.gameObject.GetComponent<PlayerMovementController>().RotatePlayerToTarget(transform);

                if (time >= timeToHarvest)
                {
                    player.gameObject.GetComponent<PlayerStateMachine>().SetState(playerStates.Idle);
                    player.gameObject.GetComponent<PlayerStateMachine>().SetIdleAnim();

                    Destroy(gameObject);

                    if (!slotManager) return;

                    Debug.LogError("recogido");
                    slotManager.AddItem(item.inventoryItemInfo.itemId, item);
                    
                }
                else
                {
                    time += Time.deltaTime;
                }
            }
            else
            {
                time = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            isIn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isIn = false;
            player.gameObject.GetComponent<PlayerStateMachine>().SetState(playerStates.Idle);
        }
    }
    private float GetProgress()
    {
        return time / timeToHarvest;
    }
    public void setItem(InventoryItem2_0 _item)
    {
        item = _item;
    }

    public IEnumerator Harvesting()
    {

        yield return null;
    }
}
