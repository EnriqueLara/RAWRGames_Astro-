using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] ModuleSelection mSelection;
    [SerializeField] LevelSaverLoader levelSaverLoader;
    [SerializeField] NavMeshGenerator nmGenerator;
    [SerializeField] EnemySpawner enemySpawner;
    public ChangeScene changeScene;
    public GameObject player;
    private GameObject startRoomPrefab;
    public GameObject endRoomPrefab;
    public GameObject chestRoomPrefab;
    public List<GameObject> roomGameObject = new List<GameObject>();
    public List<Room> roomPrefabs = new List<Room>();

    [Tooltip("The number of rooms to generate")]
    public Vector2 iterationRange = new Vector2();

    public List<Doorway> availableDoorways = new List<Doorway>();

    Room startRoom;
    EndRoom endRoom;

    public List<Room> placedRooms = new List<Room>();

    LayerMask roomLayerMask;

    public bool levelGenerated;

    private void Start()
    {
        roomLayerMask = LayerMask.GetMask("Room");
        levelSaverLoader.LoadRoomStatus(ref levelGenerated);
        if (!levelGenerated) StartCoroutine("GenerateLevel");
    }
    IEnumerator GenerateLevel()
    {
        WaitForSeconds startup = new WaitForSeconds(1);
        WaitForFixedUpdate interval = new WaitForFixedUpdate();

        yield return startup;


        //asignar los prefabs a la lista
        mSelection.SetStartRoomModulePrefabs(ref startRoomPrefab);
        mSelection.SetEndRoom(ref endRoomPrefab);
        mSelection.SetChestRoom(ref chestRoomPrefab);
        mSelection.SetRandomRooms(ref roomGameObject);


        //place start room
        PlaceStartRoom();

        yield return interval;

        //ramdom iterations

        int iterations = Random.Range((int)iterationRange.x, (int)iterationRange.y);

        for (int i = 0; i < iterations; i++)
        {
            //place random room from list
            PlaceRandomRoom();
            yield return interval;
        }

        //place end room
        PlaceEndRoom();
        PlaceChestRoom();

        //setHideDoorways
        SetObjects();

        yield return interval;

        yield return new WaitForSeconds(3);

        player.SetActive(true);

        levelGenerated = true;
        nmGenerator.BakeNavMesh();
        enemySpawner.SpawnEnemys();
        //StopAllCoroutines();
    }

    public void SetObjects()
    {
        foreach (Room room in placedRooms)
        {
            SetHiddenDoorways(room);
            SetEnemySpawnPoints(room);
        }
    }
    public void SetHiddenDoorways(Room room)
    {
        
        foreach (Doorway doorway in room.doorways)
        {
            room.roomData.doorwaysVisibility.Add(doorway.isActiveAndEnabled);
        }
        
    }
    public void SetEnemySpawnPoints(Room room)
    {
        
        foreach (GameObject spawnpoint in room.enemySpawnPoints)
        {
            enemySpawner.AddSpawnPointToList(spawnpoint);
        }
        
    }


    private void PlaceStartRoom()
    {

        //instantiate room
        startRoom = Instantiate(startRoomPrefab).GetComponent<Room>();
        startRoom.transform.parent = this.transform;

        //Get doorway list from current room and add them to availableDoorways list
        AddDoorwaysToList(startRoom, ref availableDoorways);

        //place start room and origin of wworld
        startRoom.transform.position = Vector3.zero;
        startRoom.transform.rotation = Quaternion.identity;

        startRoom.GetComponent<Room>().SetDoorwayVisibilityToArray();
        placedRooms.Add(startRoom);

    }
    private void PlaceRandomRoom()
    {


        //instantiate room from list
        Room currentRoom = Instantiate(roomGameObject[Random.Range(0, roomPrefabs.Count)]).GetComponent<Room>(); 
        //Room currentRoom = Instantiate(roomPrefabs[Random.Range(0,roomPrefabs.Count)]) as Room;
        currentRoom.transform.parent = this.transform;

        List<Doorway> allAvailableDoorways = new List<Doorway>(availableDoorways);
        List<Doorway> currentRoomDoorways = new List<Doorway>();
        AddDoorwaysToList(currentRoom, ref currentRoomDoorways);

        //get the list of the current room doorways and add them randomly to the availableDoorways list

        AddDoorwaysToList(currentRoom, ref availableDoorways);

        bool roomPlaced = false;

        //try all available doorways
        foreach (Doorway doorway in allAvailableDoorways)
        {
            //try all available doorways in current room
            foreach (Doorway currentRoomDoorway in currentRoomDoorways)
            {
                //position room
                PositionRoomAtDoorway(ref currentRoom, currentRoomDoorway, doorway);

                //check if room overlaps

                if (CheckRoomOverlap(currentRoom))
                {
                    continue;
                }


                roomPlaced = true;


                //add room to placedRooms list
                placedRooms.Add(currentRoom);

                //removed occupied doorways
                currentRoomDoorway.gameObject.SetActive(false);
                availableDoorways.Remove(currentRoomDoorway);

                doorway.gameObject.SetActive(false);
                availableDoorways.Remove(doorway);

                //the room has been placed and can exit the loop
                break;
            }
            //the room has been placed and can exit the loop
            if (roomPlaced)
            {
                break;
            }


        }

        //if room couldnt be placed restart the generation
        if (!roomPlaced)
        {
            foreach (Doorway doorway in currentRoom.doorways)
            {
                availableDoorways.Remove(doorway);
            }
            Destroy(currentRoom.gameObject);
            //ResetGenerator();
        }
    }
    
    private void PositionRoomAtDoorway(ref Room _room, Doorway _roomDoorway, Doorway _targetDoorway)
    {
        // reset room position and rotation
        _room.transform.position = Vector3.zero;
        _room.transform.rotation = Quaternion.identity;

        //rotateroom to match previous doorway orientation
        Vector3 targetDoorwayEuler = _targetDoorway.transform.eulerAngles;
        Vector3 roomDoorwayEuler = _roomDoorway.transform.eulerAngles;
        float deltaAngle = Mathf.DeltaAngle(roomDoorwayEuler.y, targetDoorwayEuler.y);

        Quaternion currentRoomTargetRotation = Quaternion.AngleAxis(deltaAngle, Vector3.up);
        _room.transform.rotation = currentRoomTargetRotation * Quaternion.Euler(0, 180f, 0);

        //position Room
        Vector3 roomPositionOffset = _roomDoorway.transform.position - _room.transform.position;
        _room.transform.position = _targetDoorway.transform.position - roomPositionOffset;
    }
    private bool CheckRoomOverlap(Room room)
    {
        Bounds bounds = room.roomBounds;
        bounds.center = room.transform.position;
        bounds.Expand(-0.2f);

        Collider[] colliders = Physics.OverlapBox(bounds.center, bounds.size / 2, room.transform.rotation, roomLayerMask);
        
        if (colliders.Length > 0)
        {
            //ignore collisions with current room
            foreach (Collider c in colliders)
            {

                if (c.transform.parent.gameObject.Equals(room.gameObject))
                {
                    
                    continue;
                }
                else
                {
                    
                    Debug.Log(room.name +"  is colliding with: " + c.gameObject.name);
                    Debug.LogError("ROOM OVERLAPS");
                    return true;
                }
            }
        }
        return false;
    }


    private void PlaceEndRoom()
    {

        //instantiate room from list
        Room endRoom = Instantiate(endRoomPrefab).GetComponent<Room>();
        endRoom.transform.parent = this.transform;

        endRoom.gameObject.GetComponent<EndRoomChangeLevel>().SetChangeScene(changeScene);

        List<Doorway> allAvailableDoorways = new List<Doorway>(availableDoorways);
        Doorway doorway = endRoom.doorways[0];

        bool roomPlaced = false;

        foreach (Doorway availableDoorway in allAvailableDoorways)
        {
            Room room = (Room)endRoom;
            PositionRoomAtDoorway(ref room, doorway, availableDoorway);

            if (CheckRoomOverlap(room))
            {
                continue;
            }

            roomPlaced = true;




            doorway.gameObject.SetActive(false);
            availableDoorways.Remove(doorway);
            availableDoorway.gameObject.SetActive(false);
            availableDoorways.Remove(availableDoorway);

            break;
        }

        if (!roomPlaced)
        {
            //Destroy(endRoom.gameObject);
            //ResetGenerator();
        }

        placedRooms.Add(endRoom);
    }
    private void PlaceChestRoom()
    {

        //instantiate room from list
        Room chestRoom = Instantiate(chestRoomPrefab).GetComponent<Room>();
        chestRoom.transform.parent = this.transform;

        List<Doorway> allAvailableDoorways = new List<Doorway>(availableDoorways);
        Doorway doorway = chestRoom.doorways[0];

        bool roomPlaced = false;

        foreach (Doorway availableDoorway in allAvailableDoorways)
        {
            Room room = (Room)chestRoom;
            PositionRoomAtDoorway(ref room, doorway, availableDoorway);

            if (CheckRoomOverlap(room))
            {
                continue;
            }

            roomPlaced = true;




            doorway.gameObject.SetActive(false);
            availableDoorways.Remove(doorway);
            availableDoorway.gameObject.SetActive(false);
            availableDoorways.Remove(availableDoorway);

            break;
        }

        if (!roomPlaced)
        {
            //Destroy(endRoom.gameObject);
            //ResetGenerator();
        }

        placedRooms.Add(chestRoom);
    }
    private void ResetGenerator()
    {
        //delete all rooms 
        if (startRoom) Destroy(startRoom.gameObject);
        if (endRoom) Destroy(endRoom.gameObject);

        foreach (Room room in placedRooms)
        {
            Destroy(room.gameObject);
        }

        //clear lists

        placedRooms.Clear();
        availableDoorways.Clear();
        Debug.LogWarning("GeneratorReset");
        StartCoroutine("GenerateLevel");
        
    }

    private void AddDoorwaysToList(Room _room, ref List<Doorway> _list)
    {
        foreach(Doorway doorway in _room.doorways)
        {
            int r = Random.Range(0, _list.Count);
            _list.Insert(r, doorway);               
        }
    }
}
