using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_vs : MonoBehaviour{

    private int strikes = 0;
    public GameObject strike0;
    public GameObject strike1;
    public GameObject strike2;

    public Vector3 strike_pos;

    public Text timer;
    private float starting_time;

    private int filled_cells=0;

    void Start(){
        if(Settings_vs.notimer){
            Destroy(timer);
        }
        else{
            starting_time = Time.time;
        }

        strike0 = Instantiate(strike0, strike_pos, Quaternion.identity);
        strike0.transform.SetParent(GameObject.Find("Strikes").transform, false);
    }

    void EndGame(){
        SceneManager.LoadScene("SingleGameOver");
    }

    public void FilledOneCell(){
        filled_cells++;
        if(filled_cells==81)
            SceneManager.LoadScene("SingleWon");
    }

    public void add_strike(){
        if(Settings_vs.nostrikes){
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
        if(Settings_vs.notimer){
            return;
        }
        float t = Settings_vs.timelimit - (Time.time-starting_time);
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
