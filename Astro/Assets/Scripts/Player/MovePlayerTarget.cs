using System;
using UnityEngine;

public class MovePlayerTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Joystick js;
    [SerializeField] private float targetDistance;

    private void MoveTarget()
    {
        target.position = new Vector3(transform.position.x + js.Direction.x*
            targetDistance, transform.position.y + .2f, transform.position.z + js.Direction.y* targetDistance);
    }

    private void Update()
    {
        MoveTarget();
    }
}
