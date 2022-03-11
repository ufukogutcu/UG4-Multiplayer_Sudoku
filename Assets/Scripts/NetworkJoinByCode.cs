using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NetworkJoinByCode : MonoBehaviourPunCallbacks
{

    
    public void JoinRoomByCode(InputField code){
        
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinRoom(code.text);

    }

}
