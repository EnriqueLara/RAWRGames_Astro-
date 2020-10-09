using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private JSStatus jsStatus;
    public void Move(Transform _target, float _movementSpeed)
    {
        if (jsStatus.CheckIfJSIsPressed())
        {
            rb.MovePosition(transform.position + (transform.forward * _movementSpeed * Time.deltaTime));
        }
    }
}
