using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingleMenuManager : MonoBehaviour
{

    public Toggle lives;
    public Toggle time;

    public void submit(){
        SettingsSingle.notimer = time.isOn;
        SettingsSingle.nostrikes = lives.isOn; 
        SceneManager.LoadScene("SinglePlayer");
    }
    
}
