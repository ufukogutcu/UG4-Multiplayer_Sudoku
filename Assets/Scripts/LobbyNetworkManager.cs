using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    public void GoBack()
    {

        CloseRoom();
        SceneManager.LoadScene("MultiplayerMenu");

    }

    public void CloseRoom()
    {

        PhotonNetwork.LeaveRoom();
        Debug.Log("Left lobby");

    }
}
