using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : MonoBehaviour
{
    private int column;
    private int row;
    private Board board;

    public GhostBlock(int column, int row, Board board)
    {
        this.column = column;
        this.row = row;
        this.board = board;
        board.gameGrid[column, row] = this.gameObject;//Putting the piece in the (mostly) top, left, center of the array
        //this.gameObject = Instantiate(board.tromino, new Vector2(x, y), Quaternion.identity);//putting the piece in the top left of the screen
        //block.GetComponent<Block>().movingDelay = board.movingDelay;//Telling the piece what the moving delay is currently
        //block.layer = 2;
        //inputManager.activeBlocks[spot] = block.GetComponent<Block>();
    }

    //private Block block;

    //void Awake()
    //{
    //    //board = FindObjectOfType<Board>();//Since the piece is a prefab, public variables won't work and it needs to find the board once it enters the scene.  Hey, thanks for reading this long comment! :)
    //    block = FindObjectOfType<Block>();
    //}
    void Start()
    {
        //GameObject.Instantiate(this.gameObject, new Vector2(column, FindGhostDifferenceInt(board, column)), Quaternion.identity, this.gameObject.transform);

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
