using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellData_sabotage : MonoBehaviour
{
    public int current = 0;
    public int answer = 0;

    private Vector3 pos;

    private GameObject currentobject;

    private GameObject GameManager;

    void Start() {
        pos = gameObject.GetComponent<RectTransform>().anchoredPosition;
        GameManager = GameObject.Find("GameManager");
    }
    
    void OnCollisionEnter2D(Collision2D col) {
        if (current==0)
        {
        if (col.gameObject.tag == "LeftNumbers")
            gameObject.GetComponent<Image>().color = new Color32(82,82,62,103);
        }
        else
        {
            if (col.gameObject.tag == "LeftNumbers"){
                Drag_sabotage drag = col.gameObject.GetComponent("Drag_sabotage") as Drag_sabotage;
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
                GameManager_sabotage manager = GameManager.GetComponent("GameManager_sabotage") as GameManager_sabotage;
                manager.FilledOneCell();
            }
            // If wrong answer
            else{
                GameManager_sabotage manager = GameManager.GetComponent("GameManager_sabotage") as GameManager_sabotage;
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
            pos = gameObject.GetComponent<RectTransform>().anchoredPosition;
            GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
            obj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            currentobject = obj;
            if (!GameManager){
                GameManager = GameObject.Find("GameManager");
            }
            GameManager_sabotage manager = GameManager.GetComponent("GameManager_sabotage") as GameManager_sabotage;
            manager.FilledOneCell();
        }
    }
}
