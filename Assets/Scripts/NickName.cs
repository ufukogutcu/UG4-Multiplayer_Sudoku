using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NickName : MonoBehaviourPunCallbacks
{

    public GameObject panel;

    public void setNickname(InputField code){
        string name;
        
        if(code.text==""){
            name="Player";
        }else{
            name=code.text;
        }
        PhotonNetwork.LocalPlayer.NickName = name;
        Debug.Log("Nickname set");
        Destroy(panel);

    }
}
