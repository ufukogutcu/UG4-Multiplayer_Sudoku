using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager_sabotage : MonoBehaviourPunCallbacks
{

    private int strikes = 0;
    public GameObject strike0;
    public GameObject strike1;
    public GameObject strike2;

    public Vector3 strike_pos;

    public Vector3 topleft;
    public Vector3 top;
    public Vector3 topright;
    public Vector3 left;
    public Vector3 middle;
    public Vector3 right;
    public Vector3 bottomleft;
    public Vector3 bottom;
    public Vector3 bottomright;

    public GameObject sabotage_box;

    public Text timer;
    private float starting_time;

    private int filled_cells=0;

    void Start(){
        PhotonView photonView = PhotonView.Get(this);
        if(Settings_sabotage.notimer){
            Destroy(timer);
        }
        else{
            starting_time = Time.time;
        }

        strike0 = Instantiate(strike0, strike_pos, Quaternion.identity);
        strike0.transform.SetParent(GameObject.Find("Strikes").transform, false);
    }

    private void use_time(){
        starting_time = starting_time - Settings_sabotage.sabotagecost;
    }

    public void sabotage(string box){
        use_time();
        photonView.RPC("sabotaged", RpcTarget.All, box);
    }

    [PunRPC]
    private void sabotaged(string box){
        Vector3 pos;
        if (box=="topleft")
            pos = topleft;
        else if (box=="top")
            pos = top;
        else if (box=="topright")
            pos = topright;
        else if (box=="left")
            pos = left;
        else if (box=="middle")
            pos = middle;
        else if (box=="right")
            pos = right;
        else if (box=="bottomleft")
            pos = bottomleft;
        else if (box=="bottom")
            pos = bottom;
        else if (box=="bottomright")
            pos = bottomright;
        else
            pos = middle;

        GameObject obj = Instantiate(sabotage_box, pos, Quaternion.identity);
        obj.transform.SetParent(GameObject.Find("Canvas").transform, false);

    }

    void EndGame(){
        photonView.RPC("win", RpcTarget.All);
        SceneManager.LoadScene("MultiplayerLost");
    }

    void WonGame(){
        photonView.RPC("lose", RpcTarget.All);
        SceneManager.LoadScene("MultiplayerWon");
    }

    [PunRPC]
    private void lose(){
        SceneManager.LoadScene("MultiplayerLost");
    }

    [PunRPC]
    private void win(){
        SceneManager.LoadScene("MultiplayerWon");
    }

    public void FilledOneCell(){
        filled_cells++;
        if(filled_cells==81)
            SceneManager.LoadScene("SingleWon");
    }

    public void add_strike(){
        if(Settings_sabotage.nostrikes){
            return;
        }
        strikes++;
        if (strikes == 1){
            DestroyObject(strike0);
            strike1 = Instantiate(strike1, strike_pos, Quaternion.identity);
            strike1.transform.SetParent(GameObject.Find("Strikes").transform, false);
            return;
        }
        if (strikes == 2){
            DestroyObject(strike1);
            strike2 = Instantiate(strike2, strike_pos, Quaternion.identity);
            strike2.transform.SetParent(GameObject.Find("Strikes").transform, false);
            return;
        }
        if (strikes == 3){
            EndGame();
        }
    }

    void Update(){
        if(Settings_sabotage.notimer){
            return;
        }
        float t = Settings_sabotage.timelimit - (Time.time-starting_time);
        if (t<0.0001){
            EndGame();
        }

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        if(t % 60<9.5){
            seconds = "0"+(t % 60).ToString("f0");
        }

        timer.text = minutes+":"+seconds;
    }


}
