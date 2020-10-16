using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenController : MonoBehaviour
{
    public Text oxygenText;

    private void Update()
    {
        if(GameManager.instance)
        oxygenText.text = GameManager.instance.oxygenSystem.GetOxygen().ToString();
    }
}
