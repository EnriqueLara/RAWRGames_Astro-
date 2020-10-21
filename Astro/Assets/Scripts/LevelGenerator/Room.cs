using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room : MonoBehaviour
{
    public MeshCollider meshCollider;
    public RoomData roomData;
    public Doorway[] doorways;
    public GameObject[] enemySpawnPoints;


    public Bounds roomBounds
    {
        get{ return meshCollider.bounds; }
    }
    public void Start()
    {
        SetTransform();
    }

    public void SetTransform()
    {
        //position
        roomData.transformX = transform.position.x;
        roomData.transformY = transform.position.y;
        roomData.transformZ = transform.position.z;

        //rotation
        roomData.rotationX = transform.rotation.eulerAngles.x;
        roomData.rotationY = transform.rotation.eulerAngles.y;
        roomData.rotationZ = transform.rotation.eulerAngles.z;
    }
    public void SetDoorwayVisibilityToArray()
    {
        foreach (Doorway doorway in doorways)
        {
            roomData.doorwaysVisibility.Add(doorway.isActiveAndEnabled);
        }
    }
}
