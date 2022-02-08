using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingleMenuManager : MonoBehaviour
{

    public Toggle lives;
    public Toggle time;

    public Toggle easy;
    public Toggle medium;
    public Toggle hard;

    public void submit(){
        SettingsSingle.notimer = time.isOn;
        SettingsSingle.nostrikes = lives.isOn; 

        if (easy.isOn)
            SettingsSingle.difficulty = 1;
        else if (medium.isOn)
            SettingsSingle.difficulty = 2;
        else
            SettingsSingle.difficulty = 3;

        SceneManager.LoadScene("SinglePlayer");
    }
    
}
