﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class HostGamemodeHandler : MonoBehaviour
{
    public Toggle gamemode1;
    public Toggle gamemode2;
    public Toggle gamemode3;

    public void submit(){
        if (gamemode1.isOn)
        {PhotonNetwork.LoadLevel("MULTI-COOP");}
        if (gamemode2.isOn)
        {}
        if (gamemode3.isOn)
        {}
    }
}