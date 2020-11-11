using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private RotatePlayer rotatePlayer;
    [SerializeField] private Transform moveTarget;
    [SerializeField] private MovePlayer movePlayer;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    
    
    public void MovePlayer()
    {
        rotatePlayer.Rotate(moveTarget,rotationSpeed);
        movePlayer.Move(moveTarget,movementSpeed);
    }
    public float CalculateSpeed()
    {
        return movePlayer.CalculateSpeed();
    }

    public void RotatePlayerToTarget(Transform _target)
    {
        rotatePlayer.Rotate(_target, rotationSpeed);
    }
}
