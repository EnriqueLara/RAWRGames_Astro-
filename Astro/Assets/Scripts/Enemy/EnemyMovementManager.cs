using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementManager : MonoBehaviour
{
    public NavMeshAgent agent;
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed;
    [SerializeField] float targetRange;
    private bool ShouldStopMoving=true;

    public void FollowPlayer()
    {
        if (target)
        {
            ShouldStop();
            agent.SetDestination(target.position);
            agent.isStopped = ShouldStopMoving;
        }
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
    public void ShouldStop()
    {
        if (Vector3.Distance(this.transform.position, target.position) > targetRange * 2)
        {
            ShouldStopMoving = true;
        }
        if(Vector3.Distance(this.transform.position, target.position) < targetRange)
        {
            ShouldStopMoving = false;
        }
    }
}
