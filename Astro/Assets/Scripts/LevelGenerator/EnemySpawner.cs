using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform enemiesTarget;
    [SerializeField] FindClosestEnemy findEnemy;
    [SerializeField] List<GameObject> spawnPoints;
    [SerializeField] List<GameObject> availableSpawnPoints;

    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] Vector2 enemyAmountRange;
    [SerializeField] Transform container;


    public void AddSpawnPointToList(GameObject spawnPoint)
    {
        spawnPoints.Add(spawnPoint);
        availableSpawnPoints.Add(spawnPoint);
    }
    public void SpawnEnemys()
    {
        int e = (int)Random.Range(enemyAmountRange.x, enemyAmountRange.y);

        for (int i = 0; i <= e; i++)
        {
            var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], container);
            enemy.GetComponent<EnemyMovementManager>().SetTarget(enemiesTarget);
            PlaceEnemyAtAvailableSpawnPoint(ref enemy);
            findEnemy.AddEnemy(enemy.GetComponent<EnemyController>());
        }
    }
    public void PlaceEnemyAtAvailableSpawnPoint(ref GameObject enemy)
    {
        var currentSpawnPoint = availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
        Vector3 newPos = currentSpawnPoint.transform.position;
        enemy.transform.position = newPos;
        Debug.Log(currentSpawnPoint.transform.position);
        availableSpawnPoints.Remove(currentSpawnPoint);
    }
    
}


