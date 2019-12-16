using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : MonoBehaviour
{

    private Block block;

    void Awake()
    {
        //board = FindObjectOfType<Board>();//Since the piece is a prefab, public variables won't work and it needs to find the board once it enters the scene.  Hey, thanks for reading this long comment! :)
        block = FindObjectOfType<Block>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Submit") && Board.isInputEnabled)
        {
            Destroy(gameObject);
        }
    }

    public int FindGhostDifferenceInt(Board board, int column)
    {
        int checkFromTop = board.height - 4;
        while (board.gameGrid[column, checkFromTop] == null)
        {
            checkFromTop--;//try the one below
                           //dont let the counter check below zero
            if (checkFromTop == -1)
            {
                break;
            }

        }
        return  checkFromTop+1;
    }
    public void PlaceGhostBlock(int column, GameObject block, Board board) //Same as PlaceBlock but it does not update the gameGrid array.
    {
        this.gameObject.transform.position = new Vector2(column, FindGhostDifferenceInt(board, column));
    }
}
