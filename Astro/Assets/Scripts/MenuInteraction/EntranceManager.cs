using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AreaEnums;
using Tags;

public class EntranceManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] MI_CameraMovement cameraMovement;
    [SerializeField] MI_ShowHideCanvas HSCanvas;
    [Header("Canvas")]
    [SerializeField] GameObject pannelInteraction;
    [Header("")]
    [Tooltip("Area name, this name will appear on the button")]
    [SerializeField] AreaEnum areaEnum;
    [SerializeField] Transform cameraPos;
    [SerializeField] float transitionSpeed;

    private void Start()
    {
        HSCanvas.HideMenuInteractionCanvas();
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag.PLAYER)
        {
            HSCanvas.ShowMenuInteractionCanvas();
            cameraMovement.SetNewCameraPos(cameraPos);
            cameraMovement.SetTransitionSpeed(transitionSpeed);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tag.PLAYER)
        {
            HSCanvas.HideMenuInteractionCanvas();
        }
    }



    //Player enters
    //show button ,assign which camera pos and canvas to show
    //when Enter button pressed, Hide Enter button, show exit button, move camera to pos, show canvas

}
