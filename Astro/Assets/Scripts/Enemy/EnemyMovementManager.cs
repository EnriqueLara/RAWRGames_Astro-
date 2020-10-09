using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementManager : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed;

    public void FollowPlayer()
    {
        if(target)
        agent.SetDestination(target.position);
        else Debug.LogError("EnemyMovementManager has no target");
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    public void SetSpeed(float _movementSpeed)
    {
        movementSpeed = _movementSpeed;
    }
}
