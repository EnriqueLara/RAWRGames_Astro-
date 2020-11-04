using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStates;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField]
    private playerStates state;

    private PlayerMovementController playerMovement;
    [SerializeField] private FindClosestEnemy findEnemy;
    [SerializeField] private Animator playerAnim;
    [SerializeField]
    private HealthManager playerStats;
    [SerializeField]
    private JSStatus jsStatus;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovementController>();
    }
    private void Update()
    {
        if(state != playerStates.Dead)
        {
            CheckIfIdle();
            CheckIfRunning();
            CheckIfShooting();
        }
        //CheckIfDead();
        
        //if(state == playerStates.Harvesting)
        //{
        //    playerAnim.SetTrigger("Harvesting");
        //}
        //if (state == playerStates.Idle)
        //{
        //    playerAnim.SetTrigger("Idle");
        //}
        //if (state == playerStates.Shooting)
        //{
        //    playerAnim.SetTrigger("Shooting");
        //}
        //if (state == playerStates.Running)
        //{
        //    playerAnim.SetTrigger("Running");
        //}
    }
    public playerStates GetState()
    {
        return state;
    }
    public void SetState(playerStates _state)
    {
        if(state != playerStates.Dead)
        state = _state;
    }

    //Idle
    private void CheckIfIdle()
    {
        if (!jsStatus.CheckIfJSIsPressed() && !findEnemy.AreEnemies() && state != playerStates.Harvesting && state != playerStates.Dead) 
        {
            state = playerStates.Idle;
            SetIdleAnim();
        }
    }

    //Running
    private void CheckIfRunning()
    {
        if(jsStatus.CheckIfJSIsPressed())
        {
            state = playerStates.Running;
            playerAnim.SetBool("IsShooting", false);
            playerAnim.SetBool("IsInIdle", false);
            playerAnim.SetBool("IsRunning", true);
            playerAnim.SetBool("IsHarvesting", false);
            playerAnim.SetBool("IsDead", false);
        }
    }
    //Shooting
    private void CheckIfShooting()
    {
        if (!jsStatus.CheckIfJSIsPressed() && findEnemy.AreEnemies())
        {
            state = playerStates.Shooting;
            playerAnim.SetBool("IsShooting", true);
            playerAnim.SetBool("IsInIdle", false);
            playerAnim.SetBool("IsRunning", false);
            playerAnim.SetBool("IsHarvesting", false);
            playerAnim.SetBool("IsDead", false);
        }
    }

    public void CheckIfDead()
    {
        if(playerStats.GetHealth() <= 0)
        {
            state = playerStates.Dead;
            playerAnim.SetBool("IsShooting", false);
            playerAnim.SetBool("IsInIdle", false);
            playerAnim.SetBool("IsRunning", false);
            playerAnim.SetBool("IsHarvesting", false);
            playerAnim.SetBool("IsDead", true);
            Debug.Log("Murio");
        }
    }

    public void SetHarvestingAnim()
    {
        playerAnim.SetBool("IsShooting", false);
        playerAnim.SetBool("IsInIdle", false);
        playerAnim.SetBool("IsRunning", false);
        playerAnim.SetBool("IsHarvesting", true);
        playerAnim.SetBool("IsDead", false);
    }
    public void SetIdleAnim()
    {
        playerAnim.SetBool("IsShooting", false);
        playerAnim.SetBool("IsInIdle", true);
        playerAnim.SetBool("IsRunning", false);
        playerAnim.SetBool("IsHarvesting", false);
        playerAnim.SetBool("IsDead", false);
    }


}
