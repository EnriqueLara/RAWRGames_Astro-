using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStates;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    MovePlayer movePlayer;
    PlayerStateMachine playerStateMachine;

    [SerializeField] playerStates state;


    // Start is called before the first frame update
    void Start()
    {
        playerStateMachine = GetComponent<PlayerStateMachine>();
        movePlayer = GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        state = playerStateMachine.GetState();
        //CheckIfDead();

        //if(state == playerStates.Harvesting)
        //{
        //    playerAnim.SetTrigger("Harvesting");
        //}
        if (state == playerStates.Idle)
        {
            //animator.SetTrigger("Idle");

            animator.SetBool("IsShooting", false);
            animator.SetBool("IsInIdle", true);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsHarvesting", false);
            animator.SetBool("IsDead", false);
        }
        if (state == playerStates.Shooting)
        {
            //animator.SetTrigger("Shooting");


            animator.SetBool("IsShooting", true);
            animator.SetBool("IsInIdle", false);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsHarvesting", false);
            animator.SetBool("IsDead", false);
        }
        if (state == playerStates.Running)
        {
            //animator.SetTrigger("Running");
            animator.SetBool("IsShooting", false);
            animator.SetBool("IsInIdle", false);
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsHarvesting", false);
            animator.SetBool("IsDead", false);
        }



        animator.SetFloat("Speed", movePlayer.CalculateSpeed());
    }
}
