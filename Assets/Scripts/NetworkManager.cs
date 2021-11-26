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

    private void Awake()
    {

      PhotonNetwork.AutomaticallySyncScene = true;

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

    public void CreateRoom()
    {

      PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers=2 });

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

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        //PhotonNetwork.LoadLevel(2);
    }

    public void StartGame()
    {

      PhotonNetwork.LoadLevel("Multiplayer");

    }



}
