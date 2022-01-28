using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject prefab8;
    public GameObject prefab9;

    public GameObject cell0_0;
    public GameObject cell0_1;
    public GameObject cell0_2;
    public GameObject cell0_3;
    public GameObject cell0_4;
    public GameObject cell0_5;
    public GameObject cell0_6;
    public GameObject cell0_7;
    public GameObject cell0_8;

    void set_current(GameObject cell, int current)
    {
        CellData data = cell.GetComponent("CellData") as CellData;
        data.current = current;
    }

    void set_answer(GameObject cell, int answer)
    {
        CellData data = cell.GetComponent("CellData") as CellData;
        data.answer = answer;
    }

    int get_current(GameObject cell)
    {
        CellData data = cell.GetComponent("CellData") as CellData;
        return data.current;
    }

    int get_answer(GameObject cell)
    {
        CellData data = cell.GetComponent("CellData") as CellData;
        return data.answer;
    }

    

    void generate_board()
    {
        int a = 1;
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        
    }

    
}
