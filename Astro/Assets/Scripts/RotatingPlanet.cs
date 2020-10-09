using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlanet : MonoBehaviour
{
    [SerializeField] private float X;
    [SerializeField] private float y;
    [SerializeField] private float z;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(X  * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }
}
