using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private Board board;
    private int column;
    private int row;

    private void Start()
    {
        board = FindObjectOfType<Board>();
        column = (int)transform.position.x;
        row = (int)transform.position.y;
    }
    void Update()
    {
        if (Input.GetButtonDown("Submit"))//Also need to check if it's the active piece or not
        {
            board.allTiles[column, row] = null;
            board.allTiles[column, 0] = this.gameObject;
            transform.position = new Vector2(column, 0);//Moves the piece to the very bottom
        }
    }
}
