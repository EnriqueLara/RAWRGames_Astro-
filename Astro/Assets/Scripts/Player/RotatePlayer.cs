using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] private JSStatus jsStatus;
    [SerializeField] private FindClosestEnemy findEnemy;

    public void Rotate(Transform _target, float _rotationSpeed)
    {
        if (jsStatus.CheckIfJSIsPressed())
        {
            LookAt(_target,_rotationSpeed);
        }
        else if(findEnemy)
        {
            if (findEnemy.AreEnemies())
            {
                LookAt(findEnemy.FindEnemy(), _rotationSpeed);
            }
        }
    }

    private void LookAt(Transform _target,float _rotationSpeed)
    {
        Vector3 lookPos;
        if (_target)
        { 
            lookPos = _target.position - transform.position;
        }
        else
        {
            lookPos = transform.position;
        }

        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _rotationSpeed);
    }
}
