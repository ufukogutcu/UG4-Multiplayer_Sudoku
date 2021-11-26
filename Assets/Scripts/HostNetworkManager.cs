using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class HostNetworkManager : MonoBehaviourPunCallbacks
{
    public void GoBack()
    {

        LeaveRoom();
        SceneManager.LoadScene("MultiplayerMenu");

    }

    public void LeaveRoom()
    {

        PhotonNetwork.LeaveRoom();
        Debug.Log("Left lobby");

    }
}
