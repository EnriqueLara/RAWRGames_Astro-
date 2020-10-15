using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerDetection : MonoBehaviour
{
    public EndRoomChangeLevel changeScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (changeScene)
            {
                changeScene.NextScene();
            }
        }
    }
}
