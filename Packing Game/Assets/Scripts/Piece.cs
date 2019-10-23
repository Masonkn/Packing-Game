using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private Board board;
    private int column;
    private int row;
    private int checkedRow;//A number used to see if a row is empty
    private bool onTop = true;

    private void Start()
    {
        board = FindObjectOfType<Board>();//Since the piece is a prefab, public variables won't work and it needs to find the board once it enter the scene.  Hey, thanks for reading this long comment! :)
        column = (int)transform.position.x;//Figuring out it's position
        row = (int)transform.position.y;
    }
    void Update()
    {
        if (Input.GetButtonDown("Submit") && onTop)
        {
            board.allTiles[column, row] = null;//Clearing out the spot it was in
            board.SpawnNewPiece();//And replacing it
            transform.position = new Vector2(column, FindBottom());//Moves position to the bottom
            board.allTiles[column, FindBottom()] = this.gameObject;//Moves index to the bottom
            onTop = false;
        }
    }

    int FindBottom()
    {
        checkedRow = 0;//Just a precaution.  If the position is moved after the index and this line wasn't here I think it would break.
        while (board.allTiles[column,checkedRow] != null)//If the row is not empty
        {
            checkedRow++;//try the one above
        }
        return checkedRow;
    }
}
