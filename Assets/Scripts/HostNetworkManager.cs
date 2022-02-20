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
        waiting();
        Debug.Log("Lobby Created");

    }

    public Text waiting_for_players_prefab;
    private Vector3 waiting_for_players_pos = new Vector3(1,1,1);
    private Text waiting_for_players;

    public Text joined_players_prefab;
    private Vector3 joined_players_pos = new Vector3(1,1,1);
    private Text joined_players;
    
    public GameObject start_panel_prefab;
    private Vector3 start_panel_pos = new Vector3(1,1,1);
    private GameObject start_panel;

    private void waiting(){
        if (joined_players)
            Destroy(joined_players);
        if (start_panel)
            Destroy(start_panel);
        waiting_for_players = Instantiate(waiting_for_players_prefab, waiting_for_players_pos, Quaternion.identity) as Text;
        waiting_for_players.transform.SetParent(GameObject.Find("Canvas").transform, false);
    }

    private void ready(string playername){
        Destroy(waiting_for_players);
        joined_players = Instantiate(joined_players_prefab, joined_players_pos, Quaternion.identity) as Text;
        joined_players.transform.SetParent(GameObject.Find("Canvas").transform, false);
        joined_players.text = playername + " is ready to play";

        start_panel = Instantiate(start_panel_prefab, start_panel_pos, Quaternion.identity);
        start_panel.transform.SetParent(GameObject.Find("Canvas").transform, false);
    }

    public override void OnPlayerEnteredRoom(Player player){
        ready(player.NickName);
    }

    public override void OnPlayerLeftRoom(Player player){
        waiting();
    }

    private string RandomCode(){
        return "abcde";
    }


}
