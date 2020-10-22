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
    public GameObject[] resourceSpawnPoints;
    public List<SpawnPoint> enemySpawnPointsPos;
    public List<SpawnPoint> resourceSpawnPointsPos;


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

        SetEnemySpawnPointsPos();
        SetResourceSpawnPoints();


    }
    public void SetEnemySpawnPointsPos()
    {
        if (enemySpawnPoints.Length <= 0) return;
        for (int i = 0; i < enemySpawnPoints.Length; i++)
        {
            SpawnPoint aux = new SpawnPoint();

            aux.posX = enemySpawnPoints[i].transform.position.x;
            aux.posY = enemySpawnPoints[i].transform.position.y;
            aux.posZ = enemySpawnPoints[i].transform.position.z;

            enemySpawnPointsPos.Add(aux);
        }
    }
    public void SetResourceSpawnPoints()
    {
        if (resourceSpawnPoints.Length <= 0) return;
        for (int i = 0; i < resourceSpawnPoints.Length; i++)
        {
            SpawnPoint aux = new SpawnPoint();

            aux.posX = resourceSpawnPoints[i].transform.position.x;
            aux.posY = resourceSpawnPoints[i].transform.position.y;
            aux.posZ = resourceSpawnPoints[i].transform.position.z;

            resourceSpawnPointsPos.Add(aux);
        }
    }
    public void SetDoorwayVisibilityToArray()
    {
        roomData.doorwaysVisibility.Clear();
        foreach (Doorway doorway in doorways)
        {
            roomData.doorwaysVisibility.Add(doorway.isActiveAndEnabled);
        }
    }
}
