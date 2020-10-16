using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventoryUI : MonoBehaviour
{
    public KeyCode input;
    public bool showInvUI;
    public Canvas invCanvas;

    private void Start()
    {
        invCanvas.enabled = showInvUI;
    }
    // Update is called once per frame
    void Update()
    {
            if(Input.GetKeyDown(input))
            {
            ShowHideUI();
            }
    }
    public void ShowHideUI()
    {
        showInvUI = !showInvUI;
        invCanvas.enabled = showInvUI;
    }
}
