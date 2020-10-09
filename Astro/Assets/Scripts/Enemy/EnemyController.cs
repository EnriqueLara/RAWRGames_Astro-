using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyHealthManager enemyHealthManager;
    [SerializeField] private EnemyMovementManager enemyMovementManager;


    private void Start()
    {
        enemyHealthManager.SetInitialHealth();
    }

    private void Update()
    {
        enemyMovementManager.FollowPlayer();
    }
}
