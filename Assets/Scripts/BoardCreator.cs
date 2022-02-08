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
    public GameObject cell1_0;
    public GameObject cell1_1;
    public GameObject cell1_2;
    public GameObject cell1_3;
    public GameObject cell1_4;
    public GameObject cell1_5;
    public GameObject cell1_6;
    public GameObject cell1_7;
    public GameObject cell1_8;
    public GameObject cell2_0;
    public GameObject cell2_1;
    public GameObject cell2_2;
    public GameObject cell2_3;
    public GameObject cell2_4;
    public GameObject cell2_5;
    public GameObject cell2_6;
    public GameObject cell2_7;
    public GameObject cell2_8;
    public GameObject cell3_0;
    public GameObject cell3_1;
    public GameObject cell3_2;
    public GameObject cell3_3;
    public GameObject cell3_4;
    public GameObject cell3_5;
    public GameObject cell3_6;
    public GameObject cell3_7;
    public GameObject cell3_8;
    public GameObject cell4_0;
    public GameObject cell4_1;
    public GameObject cell4_2;
    public GameObject cell4_3;
    public GameObject cell4_4;
    public GameObject cell4_5;
    public GameObject cell4_6;
    public GameObject cell4_7;
    public GameObject cell4_8;
    public GameObject cell5_0;
    public GameObject cell5_1;
    public GameObject cell5_2;
    public GameObject cell5_3;
    public GameObject cell5_4;
    public GameObject cell5_5;
    public GameObject cell5_6;
    public GameObject cell5_7;
    public GameObject cell5_8;
    public GameObject cell6_0;
    public GameObject cell6_1;
    public GameObject cell6_2;
    public GameObject cell6_3;
    public GameObject cell6_4;
    public GameObject cell6_5;
    public GameObject cell6_6;
    public GameObject cell6_7;
    public GameObject cell6_8;
    public GameObject cell7_0;
    public GameObject cell7_1;
    public GameObject cell7_2;
    public GameObject cell7_3;
    public GameObject cell7_4;
    public GameObject cell7_5;
    public GameObject cell7_6;
    public GameObject cell7_7;
    public GameObject cell7_8;
    public GameObject cell8_0;
    public GameObject cell8_1;
    public GameObject cell8_2;
    public GameObject cell8_3;
    public GameObject cell8_4;
    public GameObject cell8_5;
    public GameObject cell8_6;
    public GameObject cell8_7;
    public GameObject cell8_8;

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

    bool placeable(int[,] board, int row, int col, int num){
        int row0 = row - (row % 3);
        int col0 = col - (col % 3);

        for (int i = 0;i < 3;i++){
            for (int j = 0; j < 3; j++){
                if (board[(row0+i),(col0+j)] == num){
                    return false;
                }
            }
        }
        for (int j = 0;j <= 8;j++){
            if (board[row,j] == num){
                return false;
            }
        }
        for (int i = 0;i <= 8;i++){
            if (board[i,col] == num){
                return false;
            }
        }
        return true;
    }
    //for board generation
    bool generate(int[,] board, int row=0, int col=0){
        if (col == 8 && row == 8){
            for (int i = 1;i<10;i++){
                if (placeable(board, row, col, i)){
                    board[row,col] = i;
                    return true;
                }
            }
        }
        if (col == 9) {
            col = 0;
            row++;
        }
        if (board[row,col] != 0){
            return generate(board, row, (col+1));
        }
        int[] numbers = {1,2,3,4,5,6,7,8,9};
        List<int> unused = new List<int>(numbers);
        for (int i = 1; i < 10; i++) {
            int randomindex = Random.Range(0,unused.Count);
            int num = unused[randomindex];
            unused.RemoveAt(randomindex);
            if (placeable(board, row, col, num)) {
                board[row,col] = num;
                if (generate(board, row, (col+1))){
                    return true;
                }
            }
            board[row,col] = 0;
        }
        return false;
    }

    //for board solving
    bool solve(int[,] board, int row=0, int col=0){

        if (col == 8 && row == 8){
            return true;
        }
        if (col == 9) {
            col = 0;
            row++;
        }
        if (board[row,col] != 0){
            return solve(board, row, (col+1));
        }
        for (int num = 1; num < 10; num++) {
            if (placeable(board, row, col, num)) {
                board[row,col] = num;
                if (solve(board, row, (col+1))){
                    return true;
                }
            }
            board[row,col] = 0;
        }
        return false;
    }
    
    int[,] generate_board()
    {
        int[,] board = new int[9,9];
        generate(board);
        return board;
    }

    int[,] generate_unsolved_board(int[,] board){
        return board;
    }

    void spawn_board()
    {
        int[,] board = generate_board();
        int[,] solution_board = board;
        board = generate_unsolved_board(board);
        GameObject[,] cells = {{cell0_0,cell0_1,cell0_2,cell0_3,cell0_4,cell0_5,cell0_6,cell0_7,cell0_8},{cell1_0,cell1_1,cell1_2,cell1_3,cell1_4,cell1_5,cell1_6,cell1_7,cell1_8},{cell2_0,cell2_1,cell2_2,cell2_3,cell2_4,cell2_5,cell2_6,cell2_7,cell2_8},{cell3_0,cell3_1,cell3_2,cell3_3,cell3_4,cell3_5,cell3_6,cell3_7,cell3_8},{cell4_0,cell4_1,cell4_2,cell4_3,cell4_4,cell4_5,cell4_6,cell4_7,cell4_8},{cell5_0,cell5_1,cell5_2,cell5_3,cell5_4,cell5_5,cell5_6,cell5_7,cell5_8},{cell6_0,cell6_1,cell6_2,cell6_3,cell6_4,cell6_5,cell6_6,cell6_7,cell6_8},{cell7_0,cell7_1,cell7_2,cell7_3,cell7_4,cell7_5,cell7_6,cell7_7,cell7_8},{cell8_0,cell8_1,cell8_2,cell8_3,cell8_4,cell8_5,cell8_6,cell8_7,cell8_8}}; 
        for (int i = 0; i < 9;i++) {
            for (int j = 0; j < 9;j++){
            CellData data = cells[i,j].GetComponent("CellData") as CellData;
            data.admin_place(board[i,j],solution_board[i,j],prefab(board[i,j]));
            }
        }

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
