using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MI_ShowHideCanvas : MonoBehaviour
{
    [SerializeField] Button enterButton;
    [SerializeField] Button exitButton;
    [SerializeField] GameObject player;
    [SerializeField] Canvas menuInteractionCanvas;
    [SerializeField] Canvas JsCanvas;



    public void HideEnterBUtton()
    {
        enterButton.gameObject.SetActive(false);
    }
    public void ShowEnterBUtton()
    {
        enterButton.gameObject.SetActive(true);
    }
    public void HideExitBUtton()
    {
        exitButton.gameObject.SetActive(false);
    }
    public void ShowExitBUtton()
    {
        exitButton.gameObject.SetActive(true);
    }
    public void HideMenuInteractionCanvas()
    {
        menuInteractionCanvas.gameObject.SetActive(false);
    }
    public void ShowMenuInteractionCanvas()
    {
        menuInteractionCanvas.gameObject.SetActive(true);
    }
    public void HideJsCanvas()
    {
        JsCanvas.gameObject.SetActive(false);
    }
    public void ShowJsCanvas()
    {
        JsCanvas.gameObject.SetActive(true);
    }
    public void SetPlayerVisibility(bool _visibility)
    {
        player.SetActive(_visibility);
    }
}
