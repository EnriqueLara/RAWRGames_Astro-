using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MI_CameraMovement : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] MI_ShowHideCanvas SHCanvas;
    Vector3 prevCameraPos;
    Quaternion prevCameraRot;
    Vector3 newCameraPos;
    Quaternion newCameraRot;
    Vector3 auxNewCameraPos;
    Quaternion auxNewCameraRot;
    bool isInPlace;
    float transitionSpeed;



    private void Update()
    {
        if (!mainCamera.GetComponent<CameraFollow>())
        {
            Debug.LogError("The camera hasnt CameraFollow attached");
            return;
        }


        if (mainCamera.GetComponent<CameraFollow>().shouldFollow)
            return;
        if (Vector3.Distance(mainCamera.transform.position, newCameraPos) > .05f)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, newCameraPos, transitionSpeed * Time.deltaTime);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, newCameraRot, transitionSpeed * Time.deltaTime);
        }
        else if(!isInPlace)
        {
            //should follow the player and activate js canvas
            mainCamera.GetComponent<CameraFollow>().shouldFollow = true;
            SHCanvas.ShowJsCanvas();
        }
    }
    public void ChangeCameraPosToPlayer()
    {
        newCameraPos = mainCamera.GetComponent<CameraFollow>().newPos;
        newCameraRot = prevCameraRot;
        isInPlace = false;
    }
    public void SetNewCameraPos(Transform _transform)
    {
        auxNewCameraPos = _transform.position;
        auxNewCameraRot = _transform.rotation;
    }
    public void SetTransitionSpeed(float _transitionSpeed)
    {
        transitionSpeed = _transitionSpeed;
    }
    public void ChangeCameraPosToArea()
    {
        newCameraPos = auxNewCameraPos;
        newCameraRot = auxNewCameraRot;

        prevCameraPos = mainCamera.transform.position;
        prevCameraRot = mainCamera.transform.rotation;

        //exitButtonObject.SetActive(true);
        //buttonObject.SetActive(false);
        //player.SetActive(false);

        //mainCamera.GetComponent<CameraFollow>().shouldFollow = false;
        //jSCanvas.SetActive(false);
        isInPlace = true;
    }
}