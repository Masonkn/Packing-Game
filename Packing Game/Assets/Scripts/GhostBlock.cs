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

    public int FindGhostDifferenceInt(Board board)
    {
        int checkFromTop = board.height - 3;
        while (board.gameGrid[board.width-1, checkFromTop] == null)
            //checkFromTop == 0) If the row is not empty
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
    public void PlaceGhostBlock(int column, int row, GameObject block, Board board) //Same as PlaceBlock but it does not update the gameGrid array.
    {
        block.transform.position = new Vector2(column, FindGhostDifferenceInt(board));
    }


}
