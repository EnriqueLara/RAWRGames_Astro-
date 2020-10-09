using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStatesEnum;

public class PlayerStates : MonoBehaviour
{
    [SerializeField] private playerStates currentState;
    [SerializeField] private JSStatus jsStatus;
    [SerializeField] private FindClosestEnemy findEnemy;

    private void Update()
    {
        if (currentState == playerStates.Dead) return;
        CheckIfIdle();
        CheckIfRunning();
        CheckIfShooting();
    }

    public playerStates GetPlayerCurrentState()
    {
        return currentState;
    }

    private void CheckIfIdle()
    {
        if (!jsStatus.CheckIfJSIsPressed() && !findEnemy.AreEnemies() && currentState != playerStates.Harvesting && currentState != playerStates.Dead) 
        {
            currentState = playerStates.Idle;
            //SetIdleAnim();
        }
    }

    private void CheckIfRunning()
    {
        if (jsStatus.CheckIfJSIsPressed())
        {
            currentState = playerStates.Running;
        }
    }
    private void CheckIfShooting()
    {
        if (!jsStatus.CheckIfJSIsPressed() && findEnemy.AreEnemies())
        {
            currentState = playerStates.Shooting;
            // playerAnim.SetBool("IsShooting", true);
            // playerAnim.SetBool("IsInIdle", false);
            // playerAnim.SetBool("IsRunning", false);
            // playerAnim.SetBool("IsHarvesting", false);
            // playerAnim.SetBool("IsDead", false);
        }
    }
}
