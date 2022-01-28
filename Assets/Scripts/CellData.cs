using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellData : MonoBehaviour
{
    public int current = 0;
    public int answer = 0;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "LeftNumbers")
            gameObject.GetComponent<Image>().color = new Color32(82,82,62,103);
    }

    void OnCollisionExit2D(Collision2D col) {
 
        if (col.gameObject.tag == "LeftNumbers")
            gameObject.GetComponent<Image>().color = new Color32(82,82,62,0);
    }
}
