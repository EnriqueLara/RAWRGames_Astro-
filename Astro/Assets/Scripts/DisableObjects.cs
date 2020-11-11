using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjects : MonoBehaviour
{
    [SerializeField] GameObject[] objects;



    public void DisableSpecificObject(int _arrayPos)
    {
        objects[_arrayPos].SetActive(false);
    }
    public void EnableSpecificObject(int _arrayPos)
    {
        objects[_arrayPos].SetActive(true);
    }
}
