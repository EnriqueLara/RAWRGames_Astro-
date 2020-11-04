using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovementController playerMC;
    [SerializeField] private ShootSystem shootSystem;
    [SerializeField] private bool isTheMenuPlayer;
    [SerializeField] Animator animator;


    private void FixedUpdate()
    {
        playerMC.MovePlayer();
        if(shootSystem) shootSystem.Shoot();


        if (isTheMenuPlayer)
        {
            animator.SetFloat("Speed", playerMC.CalculateSpeed());
        }
    }
}
