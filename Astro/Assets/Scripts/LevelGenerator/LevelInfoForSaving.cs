
using System.Collections.Generic;
[System.Serializable]
public class LevelInfoForSaving
{
    public List<RoomData> levelRooms = new List<RoomData>();
    public bool levelStatus;
    public List<ResourceInfo> savedResources;
}
