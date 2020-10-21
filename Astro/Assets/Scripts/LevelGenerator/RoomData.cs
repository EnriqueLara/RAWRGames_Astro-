using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomData
{
    public int ID;
    public string IDString;
    public float transformX;
    public float transformY;
    public float transformZ;
    public float rotationX;
    public float rotationY;
    public float rotationZ;
    public List<bool> doorwaysVisibility;
}
