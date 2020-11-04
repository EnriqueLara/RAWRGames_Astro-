using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private JSStatus jsStatus;
    [SerializeField] private Joystick js;
    public void Move(Transform _target, float _movementSpeed)
    {
        if (jsStatus.CheckIfJSIsPressed())
        {
            rb.MovePosition(transform.position + (transform.forward * _movementSpeed * Time.deltaTime * CalculateSpeed()));
        }
    }
    public float CalculateSpeed()
    {
        Vector2 jsPos;
        jsPos.x = js.Direction.x;
        jsPos.y = js.Direction.y;

        float speed = Vector2.Distance(Vector2.zero, jsPos);

        return speed;

    }
}
