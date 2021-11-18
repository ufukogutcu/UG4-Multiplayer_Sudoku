﻿using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  

public class SceneChanger: MonoBehaviour { 

    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void LoadScene(int scene) {
        SceneManager.LoadScene(scene);
    }

}   