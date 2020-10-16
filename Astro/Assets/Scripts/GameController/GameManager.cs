using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnums;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isInTutorial;
    [SerializeField]
    private GameStatus gameStatus = GameStatus.None;
    public OxygenSystem oxygenSystem;
    //public GMWeaponInfo equippedWeaponInfo;
    //public WeaponList weaponList;
    //public ItemList itemList;
    //public SaveAndLoad SyL;
    //public PlayerPersistantStats playerStats;
    public SceneManagement sceneManager;
    //public LevelController levelController;
    //public InventoryList inventory;
    //public IngameInventoryManager inventoryManager;
    public PersonalInventory personalInventoryManager;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //SyL.LoadWeaponList();
        //weaponList.UpdateWeaponList();
        //inventory.UpdateInventoryList();
        //inventory.InventoryToDictionary();
    }
    public void Start()
    {
        //itemList.UpdateItemList();
    }
    public void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //your app is NO LONGE$$anonymous$$in the background
            //SyL.LoadWeaponList();
            //SyL.Load();
            personalInventoryManager.slotManager.UpdateInventoryUI();
        }
        else
        {
            //your app is now in the background
            //SyL.SaveWeaponList();
            //SyL.Save();
        }
    }


    public GameStatus GetGameStatus()
    {
        return gameStatus;
    }
    public void SetGameStatus(GameStatus _staus)
    {
        gameStatus = _staus;
    }

    public void SaveGameStatus()
    {
        PlayerPrefs.SetString("GameStatus", gameStatus.ToString());
    }
    public void LoadGameStatus()
    {
        gameStatus = (GameStatus)System.Enum.Parse(typeof(GameStatus), PlayerPrefs.GetString("GameStatus"));
    }

}
