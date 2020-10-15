using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoomChangeLevel : MonoBehaviour
{
    [SerializeField] ChangeScene changeScene;


    

    public void NextScene()
    {
        changeScene.NextScene();
    }

    public void SetChangeScene(ChangeScene _changeScene)
    {
        changeScene = _changeScene;
    }
}
