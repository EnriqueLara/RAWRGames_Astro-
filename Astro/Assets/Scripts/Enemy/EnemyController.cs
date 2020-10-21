using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private HealthManager enemyHealthManager;
    [SerializeField] private EnemyMovementManager enemyMovementManager;


    private void Start()
    {
        enemyHealthManager.SetInitialHealth();
    }

    private void Update()
    {
        enemyMovementManager.FollowPlayer();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "PlayerEnemyRange")
    //    {
    //        other.gameObject.GetComponent<FindClosestEnemy>().AddEnemy(this);
    //    }
    //}
}
