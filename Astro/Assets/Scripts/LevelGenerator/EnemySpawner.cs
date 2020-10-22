using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform enemiesTarget;
    [SerializeField] FindClosestEnemy findEnemy;

    [SerializeField] float enemyDensity;
    [SerializeField] Transform container;
    [SerializeField] GameObject[] enemyPrefabs;

    public List<GameObject> spawnPoints;
    [SerializeField] List<GameObject> availableSpawnPoints;

    public List<GameObject> GetSpawnPoints()
    {
        return spawnPoints;
    }
    public void AddSpawnPointToList(GameObject spawnPoint)
    {
        spawnPoints.Add(spawnPoint);
        availableSpawnPoints.Add(spawnPoint);
    }
    public void SpawnEnemies()
    {
        int e = GetTheNumberOfEnemiesToSpawn();
        Debug.Log(e);
        for (int i = 0; i < e; i++)
        {
            var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], GetRandomSpawnPointPos(),Quaternion.identity,container);
            enemy.GetComponent<EnemyMovementManager>().SetTarget(enemiesTarget);
            findEnemy.AddEnemy(enemy.GetComponent<EnemyController>());
            
        }
    }
    public Vector3 GetRandomSpawnPointPos()
    {
        var currentSpawnPoint = availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
        availableSpawnPoints.Remove(currentSpawnPoint);
        return currentSpawnPoint.transform.position;
    }
    public int GetTheNumberOfEnemiesToSpawn()
    {
        if (enemyDensity < 0) enemyDensity = 0;
        if (enemyDensity > 1) enemyDensity = 1;


        float q = (float)spawnPoints.Count * enemyDensity;
        Debug.Log(q);

        return (int)((float)spawnPoints.Count * enemyDensity);
    }
    public void ClearSpawPointList()
    {
        spawnPoints.Clear();
        availableSpawnPoints.Clear();
    }
    public void SetAvailableSpawnPoints()
    {
        availableSpawnPoints.Clear();
        foreach (GameObject spawnPoint in spawnPoints)
        {
            availableSpawnPoints.Add(spawnPoint);
        }
    }

}


