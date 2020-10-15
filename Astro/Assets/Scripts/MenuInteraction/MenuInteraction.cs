using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInteraction : MonoBehaviour
{
    [SerializeField] MI_CameraMovement cameraMovement;
    [SerializeField] MI_ShowHideCanvas HSCanvas;
    [SerializeField] Camera camera;
    
    public void Enter()
    {
        HSCanvas.HideEnterBUtton();
        HSCanvas.ShowExitBUtton();

        HSCanvas.HideJsCanvas();

        HSCanvas.SetPlayerVisibility(false);

        camera.GetComponent<CameraFollow>().shouldFollow = false;
        cameraMovement.ChangeCameraPosToArea();
    }
    public void Exit()
    {
        HSCanvas.SetPlayerVisibility(true);
        cameraMovement.ChangeCameraPosToPlayer();
        HSCanvas.ShowEnterBUtton();
        HSCanvas.HideExitBUtton();
    }
    

    //Player enters
    //show button ,assign which camera pos and canvas to show
    //when enter button pressed movecamera to pos and hide enter button, hide character and JSCanvas
    //when camera is in place, show exit button, show canvas
}
