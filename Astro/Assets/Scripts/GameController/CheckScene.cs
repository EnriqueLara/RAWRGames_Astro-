﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.sceneManager.CheckScene();
    }

    
}
