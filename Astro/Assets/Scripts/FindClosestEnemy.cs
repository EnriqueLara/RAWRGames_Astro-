using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosestEnemy : MonoBehaviour
{
    private bool areThereAnyEnemies;

    private void Update()
    {
        FindEnemy();
    }

    public Transform FindEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        EnemyController closestEnemy = null;
        EnemyController[] enemies = GameObject.FindObjectsOfType<EnemyController>();
        AreEnemies(enemies);

        if(AreEnemies())
        {
            foreach(EnemyController currentEnemy in enemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                if(distanceToEnemy < distanceToClosestEnemy)
                {
                    distanceToClosestEnemy = distanceToEnemy;
                    closestEnemy = currentEnemy;
                
                }
            }
            return closestEnemy.gameObject.transform;
        }
        else
        {
            return null;
        }
    }
    public void AreEnemies(EnemyController[] _enemies)
    {
        if(_enemies.Length <= 0)
        {
            areThereAnyEnemies = false;
        }
        else
        {
            areThereAnyEnemies = true;
        }
    }
    public bool AreEnemies()
    {
        return areThereAnyEnemies;
    }
}
