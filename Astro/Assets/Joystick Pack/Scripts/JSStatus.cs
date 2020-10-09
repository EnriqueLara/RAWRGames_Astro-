using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSStatus : MonoBehaviour
{
    [SerializeField] private Joystick js;
    public bool CheckIfJSIsPressed()
    {
        if (js.Horizontal == 0 && js.Vertical == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
