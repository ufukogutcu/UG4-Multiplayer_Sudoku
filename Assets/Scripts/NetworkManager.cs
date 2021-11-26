using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    // Start is called before the first frame update
    void Start()
    {

      Connect();

    }

    public void Connect()
    {

      PhotonNetwork.ConnectUsingSettings();
      Debug.Log("Connected");

    }

    public void FindRandomRoom()
    {

      PhotonNetwork.JoinRandomRoom();
  
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {

      Debug.Log("Failed to join random room");

    }

    public override void OnJoinedRoom()
    {

      Debug.Log("Joined a room");
      SceneManager.LoadScene("LobbyMultiplayer");

    }

}
