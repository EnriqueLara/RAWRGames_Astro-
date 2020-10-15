using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    public Vector3 cameraOffset;

    public Vector3 newPos;
    public bool shouldFollow;

    // Start is called before the first frame update
    void Start()
    {
        shouldFollow = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (shouldFollow)
        { 
            FollowTarget();
            RotateCameraToTarget(target.position);
        }

    }
    private void FollowTarget()
    {
        //transform.LookAt(target);
        newPos = new Vector3(target.position.x+cameraOffset.x, target.position.y + cameraOffset.y , target.position.z + cameraOffset.z);
        transform.position = newPos;
    }
    private void RotateCameraToTarget(Vector3 _lookPos)
    {
        //var rotation = Quaternion.LookRotation(_lookPos);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);

        transform.LookAt(_lookPos);
    }

    

}