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

    GameObject prefab(int i)
    {
        if (i==1)
        {
            return prefab1;
        }
        else if (i==2)
        {
            return prefab2;
        }
        else if (i==3)
        {
            return prefab3;
        }
        else if (i==4)
        {
            return prefab4;
        }
        else if (i==5)
        {
            return prefab5;
        }
        else if (i==6)
        {
            return prefab6;
        }
        else if (i==7)
        {
            return prefab7;
        }
        else if (i==8)
        {
            return prefab8;
        }
        else if (i==9)
        {
            return prefab9;
        }
        else
        {
            return null;
        }

    }
    

    int[] generate_board()
    {
        int[] arr = new int[81];
        for ( int i = 0; i < arr.Length;i++ ) {
            arr[i] = 1;
        }
        return arr;
    }

    void spawn_board()
    {
        generate_board();

    }

    // Start is called before the first frame update
    void Start()
    {
        spawn_board();
    }

    void Update()
    {

    }

    
}
