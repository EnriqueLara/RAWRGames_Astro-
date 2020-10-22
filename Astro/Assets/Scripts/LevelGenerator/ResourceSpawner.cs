using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] ItemDatabase2_0 itemDb;

    [Tooltip("This Value Should be between 0-1")]
    [SerializeField] float resourceDensity;
    [SerializeField] GameObject[] resourcePrefabs;
    [SerializeField] Transform container;

    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] List<GameObject> availableSpawnPoints;



    public void AddSpawnPointToList(GameObject spawnPoint)
    {
        spawnPoints.Add(spawnPoint);
        availableSpawnPoints.Add(spawnPoint);
    }
    public void SpawnResource()
    {
        int e = GetTheNumberOfResourcesToSpawn();

        for (int i = 0; i <= e; i++)
        {
            var resource = Instantiate(resourcePrefabs[Random.Range(0, resourcePrefabs.Length)], GetRandomSpawnPointPos(), Quaternion.identity, container);
            
        }
    }
    public Vector3 GetRandomSpawnPointPos()
    {
        var currentSpawnPoint = availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
        availableSpawnPoints.Remove(currentSpawnPoint);
        return currentSpawnPoint.transform.position;
    }
    public int GetTheNumberOfResourcesToSpawn()
    {
        if (resourceDensity < 0) resourceDensity = 0;
        if (resourceDensity > 1) resourceDensity = 1;

        return (int)(availableSpawnPoints.Count * resourceDensity); 
    }
    public void SpawnSavedResources(List<ResourceInfo> resources)
    {
        foreach (ResourceInfo resource in resources)
        {
            if (resource.ID == string.Empty) continue;

            GameObject currentResource = Instantiate(itemDb.GetItemWithKey(resource.ID).itemUnityFields.itemDropPrefab);

            currentResource.transform.parent = container;

            currentResource.transform.position = new Vector3(resource.posX, resource.posY, resource.posZ);
        }
    }
}
