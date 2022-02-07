using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGameManager : MonoBehaviour{

private int strikes = 0;
public GameObject strike0;
public GameObject strike1;
public GameObject strike2;

public Vector3 strike_pos;

    void Start(){
        strike0 = Instantiate(strike0, strike_pos, Quaternion.identity);
        strike0.transform.SetParent(GameObject.Find("Strikes").transform, false);
    }

    void EndGame(){
        Debug.Log("end");
    }

    public void add_strike(){
        strikes++;
        if (strikes == 1){
            DestroyObject(strike0);
            strike1 = Instantiate(strike1, strike_pos, Quaternion.identity);
            strike1.transform.SetParent(GameObject.Find("Strikes").transform, false);
        }
        if (strikes == 2){
            DestroyObject(strike1);
            strike2 = Instantiate(strike2, strike_pos, Quaternion.identity);
            strike2.transform.SetParent(GameObject.Find("Strikes").transform, false);
        }
        if (strikes == 3){
            EndGame();
        }
    }


}
