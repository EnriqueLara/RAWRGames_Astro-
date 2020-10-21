using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSaverLoader : MonoBehaviour
{
    [SerializeField] ItemDatabase2_0 itemDb;
    [SerializeField] LevelBuilder lBuilder;
    [SerializeField] NavMeshGenerator nmGenerator;
    [SerializeField] EnemySpawner enemySpawner;

    [SerializeField] List<RoomData> levelRooms = new List<RoomData>();
    [SerializeField] List<RoomData> savedLevelRooms = new List<RoomData>();
    public bool teststatus;
    string saveKey;
    string saveStatuskey;

    private void Awake()
    {
        saveKey = "Level" + SceneManager.GetActiveScene().buildIndex.ToString();
        saveStatuskey = "Status";
        teststatus = LoadStatus();
    }
    private void Start()
    {
        if (LoadStatus())
        {
            LoadLevelRoomsList();
            InstantiateSavedRooms();
            nmGenerator.BakeNavMesh();
        }
    }

    private void Update()
    {
        DeveloperShortCuts();
    }
    public void InstantiateSavedRooms()
    {
        foreach (RoomData room in savedLevelRooms)
        {
            if (room.IDString == string.Empty) continue;

            //instantiate prefab

            GameObject currentRoom = Instantiate(itemDb.GetItemWithKey(room.IDString).itemUnityFields.itemDropPrefab);
            currentRoom.transform.parent = this.transform;
            //move prefab to saved location
            currentRoom.transform.position = new Vector3(room.transformX, room.transformY, room.transformZ);
            currentRoom.transform.rotation = Quaternion.Euler(room.rotationX, room.rotationY, room.rotationZ);

            for(int i = 0; i <= currentRoom.GetComponent<Room>().doorways.Length - 1; i++)
            {
                currentRoom.GetComponent<Room>().doorways[i].gameObject.SetActive(room.doorwaysVisibility[i]);
            }

        }
    }

    public void LoadLevelRoomsList()
    {
        if (SaveLoad.SaveExists(saveKey))
        {
            SetList(SaveLoad.Load<List<RoomData>>(saveKey), ref savedLevelRooms);
        }
    }


    public void SaveRoomStatus()
    {
        SaveLoad.Save<bool>(lBuilder.levelGenerated, saveStatuskey);
        Debug.Log("se guardo");
    }
    public bool LoadStatus()
    {
        if (SaveLoad.SaveExists(saveStatuskey))
            return SaveLoad.Load<bool>(saveStatuskey);
        else Debug.LogError("No hay datos guardados"); return false;
    }
    public void LoadRoomStatus(ref bool status)
    {
        if (SaveLoad.SaveExists(saveStatuskey))
        {
            status = SaveLoad.Load<bool>(saveStatuskey);
            //Debug.Log(SaveLoad.Load<bool>(saveStatuskey).ToString());
        }
    }
    public void SaveLevelRoomsList()
    {
        Debug.Log("jala");
        SetList(lBuilder.placedRooms, ref levelRooms);

        SaveLoad.Save<List<RoomData>>(levelRooms,saveKey);
    }
    public void SetList(List<Room> from , ref List<RoomData> to)
    {
        to.Clear();
        foreach (Room room in from)
        {
            to.Add(room.GetComponent<Room>().roomData);
        }
    }
    public void SetList(List<RoomData> from, ref List<RoomData> to)
    {
        foreach (RoomData room in from)
        {
            to.Add(room);
        }
    }
    public void DeveloperShortCuts()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveRoomStatus();
            SaveLevelRoomsList();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadRoomStatus(ref teststatus);
            LoadLevelRoomsList();
        }
        if (Input.GetKeyDown(KeyCode.D)) SaveLoad.DeleteAllSaveFiles();
        if (Input.GetKeyDown(KeyCode.E)) enemySpawner.SpawnEnemys();
    }



}
