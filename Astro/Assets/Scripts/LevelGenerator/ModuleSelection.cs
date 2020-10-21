using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSelection : MonoBehaviour
{
    [SerializeField] ItemDatabase2_0 itemDb;
    [SerializeField] int startRoom;
    [SerializeField] int endRoom;
    [SerializeField] int chestRoom;

    [SerializeField] List<int> levelModules = new List<int>();

    public void Awake()
    {
        itemDb.InventoryToDictionary();//this should be call in the Game Manager 
    }

    public void SetStartRoomModulePrefabs(ref  GameObject prefab)
    {
        prefab = itemDb.GetItemWithKey("LM-" + startRoom.ToString()).itemUnityFields.itemDropPrefab;

        prefab.GetComponent<Room>().roomData.IDString = "LM-" + startRoom.ToString();

        prefab.GetComponent<Room>().SetTransform();


    }
    public void SetRandomRooms(ref List<GameObject> rooms)
    {
        foreach(int roomID in levelModules)
        {
            GameObject currentRoom = itemDb.GetItemWithKey("LM-" + roomID).itemUnityFields.itemDropPrefab;
            currentRoom.GetComponent<Room>().roomData.IDString = "LM-" + roomID.ToString();
            currentRoom.GetComponent<Room>().SetTransform();

            rooms.Add(currentRoom);

        }
    }
    public void SetEndRoom(ref GameObject prefab)
    {
        prefab = itemDb.GetItemWithKey("LM-" + endRoom.ToString()).itemUnityFields.itemDropPrefab;
        prefab.GetComponent<Room>().roomData.IDString = "LM-" + endRoom.ToString();
        prefab.GetComponent<Room>().SetTransform();
    }
    public void SetChestRoom(ref GameObject prefab)
    {
        prefab = itemDb.GetItemWithKey("LM-" + chestRoom.ToString()).itemUnityFields.itemDropPrefab;
        prefab.GetComponent<Room>().roomData.IDString = "LM-" + chestRoom.ToString();
        prefab.GetComponent<Room>().SetTransform();
    }

    //ref Room _endRoom, ref Room _chestRoom, ref List<Room> _otherRooms
}
