using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStats : MonoBehaviour
{
    public ResourceInfo info;

    private void Start()
    {
        SetTransformInfo();
    }
    private void SetTransformInfo()
    {
        info.posX = transform.position.x;
        info.posY = transform.position.y;
        info.posZ = transform.position.z;
    }
    public ResourceInfo GetInfo()
    {
        return info;
    }
}
