using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

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

    public GameObject creation;

    public void CreateRoom(InputField code){

        string text = code.text;
        string room_code;

        if(text==""){
            room_code = RandomCode();
        }else{
            room_code = text;
        }

        PhotonNetwork.CreateRoom(room_code, new RoomOptions { MaxPlayers=2 });
        Destroy(creation);
        Debug.Log("Lobby Created");

    }

    private string RandomCode(){
        return "abcde";
    }
}
