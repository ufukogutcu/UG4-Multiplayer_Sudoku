using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using Photon.Pun;

public class MultiLeaver : MonoBehaviourPunCallbacks
{
    public void leavetomenu(){
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Player-Main");
    }
}
