using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovementController playerMC;
    [SerializeField] private ShootSystem shootSystem;


    private void FixedUpdate()
    {
        playerMC.MovePlayer();
        if(shootSystem) shootSystem.Shoot();
         
    }
}
