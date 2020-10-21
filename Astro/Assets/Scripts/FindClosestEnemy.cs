using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestEnemy : MonoBehaviour
{
    [SerializeField] List<EnemyController> enemies;
    [SerializeField] float playerEnemyRange;
    private bool areThereAnyEnemies;

    private void Update()
    {
        FindEnemy();
    }

    public Transform FindEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        EnemyController closestEnemy = null;
        //EnemyController[] enemies = GameObject.FindObjectsOfType<EnemyController>();
        

        if(AreEnemies(enemies))
        {
            foreach (EnemyController currentEnemy in enemies.ToArray())
            {
                if (!currentEnemy.isActiveAndEnabled)
                {
                    enemies.Remove(currentEnemy);
                    continue;
                } 

                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if(distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy;
                
                }
            }
            if (!closestEnemy) return null;

            else if (Vector3.Distance(this.transform.position, closestEnemy.gameObject.transform.position) < playerEnemyRange)
            {
                return closestEnemy.gameObject.transform;
            }

            return null;
        }
        else
        {
            return null;
        }
    }
    public bool AreEnemies(List<EnemyController> _enemies)
    {
        if(_enemies.Count <= 0)
        {
            areThereAnyEnemies = false;
            return false;
        }
        else
        {
            areThereAnyEnemies = true;
            return true;
        }
    }
    public bool AreEnemies()
    {
        return areThereAnyEnemies;
    }
    public void AddEnemy(EnemyController enemy)
    {
        enemies.Add(enemy);
    }
}
