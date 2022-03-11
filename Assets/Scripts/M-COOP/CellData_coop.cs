using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellData_coop : MonoBehaviour
{
    public int current = 0;
    public int answer = 0;

    public Vector3 pos;

    private GameObject currentobject;

    public GameObject GameManager;
    
    void OnCollisionEnter2D(Collision2D col) {
        if (current==0)
        {
        if (col.gameObject.tag == "LeftNumbers")
            gameObject.GetComponent<Image>().color = new Color32(82,82,62,103);
        }
        else
        {
            if (col.gameObject.tag == "LeftNumbers"){
                Drag_coop drag = col.gameObject.GetComponent("Drag_coop") as Drag_coop;
                if (drag.number == 0)
                {
                    gameObject.GetComponent<Image>().color = new Color32(82,82,62,103);
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        
        if (col.gameObject.tag == "LeftNumbers")
            gameObject.GetComponent<Image>().color = new Color32(82,82,62,0);
    }

    public void place_value(int value,GameObject prefab)
    {
        if (current==0 && value!=0)
        {
            if (value==answer){
                current = value;
            
                GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
                obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
                currentobject = obj;
                GameManager_coop manager = GameManager.GetComponent("GameManager_coop") as GameManager_coop;
                manager.FilledOneCell();
            }
            // If wrong answer
            else{
                GameManager_coop manager = GameManager.GetComponent("GameManager_coop") as GameManager_coop;
                manager.add_strike();
            }
        }
        else
        {
            if(value==0)
            {
                Destroy(currentobject);
                current = 0;
            }
        }
    }

    public void admin_place(int currvalue, int ansvalue, GameObject prefab)
    {

        current = currvalue;
        answer = ansvalue;
            
        if (currvalue == 0)
        {
            currentobject = null;
        }
        else
        {
            GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            currentobject = obj;
            GameManager_coop manager = GameManager.GetComponent("GameManager_coop") as GameManager_coop;
            manager.FilledOneCell();
        }
    }
}
