using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BoardCreater_coop : MonoBehaviourPunCallbacks
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

    void set_current(GameObject cell, int current)
    {
        CellData data = cell.GetComponent("CellData_coop") as CellData;
        data.current = current;
    }

    void set_answer(GameObject cell, int answer)
    {
        CellData data = cell.GetComponent("CellData_coop") as CellData;
        data.answer = answer;
    }

    int get_current(GameObject cell)
    {
        CellData data = cell.GetComponent("CellData_coop") as CellData;
        return data.current;
    }

    int get_answer(GameObject cell)
    {
        CellData data = cell.GetComponent("CellData_coop") as CellData;
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
    bool solve(int[,] board, int[,] forbidden=null, int row=0, int col=0){

        if (col == 8 && row == 8){
            for (int i = 1;i<10;i++){
                if (placeable(board, row, col, i)){
                    board[row,col] = i;
                    if (board==forbidden){
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
        if (col == 9) {
            col = 0;
            row++;
        }
        if (board[row,col] != 0){
            return solve(board, forbidden, row, (col+1));
        }
        for (int num = 1; num < 10; num++) {
            if (placeable(board, row, col, num)) {
                board[row,col] = num;
                if (solve(board, forbidden, row, (col+1))){
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

    bool OneSolution(int[,] board){
        int[,] tmp_board = board;
        solve(board);
        return !solve(tmp_board,board); 
    }

    void remove_random_cells(int[,] board, int n){
        int c = 0;
        while (c<n){
            int randomi = Random.Range(0,9);
            int randomj = Random.Range(0,9);
            if(board[randomi,randomj] != 0){
                board[randomi,randomj] = 0;
                c++;
            }
        }
    }

    int[,] generate_unsolved_board(int[,] board){
        int n=Settings_coop.default_n;
        if(Settings_coop.difficulty==1)
            n=Settings_coop.easy_n;
        if(Settings_coop.difficulty==2)
            n=Settings_coop.medium_n;
        if(Settings_coop.difficulty==3)
            n=Settings_coop.hard_n;

        int[,] tmp;
        while(true){
            tmp = board.Clone() as int[,];
            remove_random_cells(tmp,n);
            if(OneSolution(tmp))
                break;
        }
        return tmp;
    }

    bool hasZero(int[,] board){
        for(int i = 0;i < 9;i++){
            for(int j = 0; j < 9;j++){
                if(board[i,j]==0){
                    return true;
                }
            }
        }
        return false;
    }

    void spawn_board()
    {
        int[,] solution_board;
        int[,] board;
        while(true){
            solution_board = generate_board();
            board = generate_unsolved_board(solution_board);
            if(hasZero(board)==true){
                break;
            }
            else{
                board = new int[9,9];
            }
        }
        for (int i = 0; i < 9;i++) {
            for (int j = 0; j < 9;j++){
                GameObject cell = (GameObject)Resources.Load("cells/cell"+i.ToString()+"_"+j.ToString(), typeof(GameObject));
                Vector3 pos = cell.transform.position;
                cell = PhotonNetwork.Instantiate(("cells/cell"+i.ToString()+"_"+j.ToString()), pos , Quaternion.identity);
                CellData_coop data = cell.GetComponent("CellData_coop") as CellData_coop;
                data.admin_place(board[i,j],solution_board[i,j],prefab(board[i,j]));
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient)
            spawn_board();
    }

    
}
