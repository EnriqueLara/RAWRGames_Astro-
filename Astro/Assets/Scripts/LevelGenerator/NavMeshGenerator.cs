using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour
{
    [SerializeField] NavMeshSurface surface;
    // Start is called before the first frame update
   
    public void BakeNavMesh()
    {
        surface.BuildNavMesh();
    }
}
