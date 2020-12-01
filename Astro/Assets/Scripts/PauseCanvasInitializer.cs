using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasInitializer : MonoBehaviour
{
    [SerializeField] GameObject menuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(true);//it needs to be active first so the SlotManager sets up the slots
        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
