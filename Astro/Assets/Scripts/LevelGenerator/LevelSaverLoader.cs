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
    [SerializeField] ResourceSpawner resourceSpawner;

    [SerializeField] Transform resourceContainer;


    [SerializeField] LevelInfoForSaving levelinfo;

    string SaveLevelInfoKey;

    private void Awake()
    {
        SaveLevelInfoKey = "LevelInfo" + SceneManager.GetActiveScene().buildIndex.ToString();

    }
    private void Start()
    {
        if (LoadStatus())
        {
            LoadLevelInfo();

            InstantiateSavedRooms();

            nmGenerator.BakeNavMesh();

            enemySpawner.SetAvailableSpawnPoints();
            enemySpawner.SpawnEnemies();

            resourceSpawner.SpawnSavedResources(levelinfo.savedResources);


        }
    }

    private void Update()
    {
        DeveloperShortCuts();
    }

    public void SetEnemySpawnPoints(GameObject room)
    {
        foreach (GameObject spawnpoint in room.GetComponent<Room>().enemySpawnPoints)

        {
            enemySpawner.AddSpawnPointToList(spawnpoint);
        }
    }
    public void SetPlacedResources()
    {
        levelinfo.savedResources.Clear();
        foreach (Transform child in resourceContainer)
        {
            levelinfo.savedResources.Add(child.GetComponent<ResourceStats>().GetInfo());
        }
    }
    public void InstantiateSavedRooms()
    {
        foreach (RoomData room in levelinfo.levelRooms)
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

            //lBuilder.placedRooms.Add(currentRoom.GetComponent<Room>());

            SetEnemySpawnPoints(currentRoom);

        }
    }

    public void LoadLevelInfo()
    {
        levelinfo = SaveLoad.Load<LevelInfoForSaving>(SaveLevelInfoKey);
    }

    public void SaveLevelInfo()
    {
        levelinfo.levelStatus = lBuilder.levelGenerated;


        if (!SaveLoad.SaveExists(SaveLevelInfoKey))
        {
            SetList(lBuilder.placedRooms, ref levelinfo.levelRooms);
        }

        SetPlacedResources();


        Debug.Log("Se Guardo");
        SaveLoad.Save<LevelInfoForSaving>(levelinfo, SaveLevelInfoKey);
    }
    public bool LoadStatus()
    {
        if (SaveLoad.SaveExists(SaveLevelInfoKey))
            return SaveLoad.Load<LevelInfoForSaving>(SaveLevelInfoKey).levelStatus;
        else Debug.LogError("No hay datos guardados"); return false;
    }
    public void LoadRoomStatus(ref bool status)
    {
        if (SaveLoad.SaveExists(SaveLevelInfoKey))
        {
            status = SaveLoad.Load<LevelInfoForSaving>(SaveLevelInfoKey).levelStatus;
        }
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
            SaveLevelInfo();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadLevelInfo();
        }
        if (Input.GetKeyDown(KeyCode.D)) SaveLoad.DeleteAllSaveFiles();
        if (Input.GetKeyDown(KeyCode.E)) enemySpawner.SpawnEnemies();
    }



}
