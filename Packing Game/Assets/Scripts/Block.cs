using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Board board;
    private int column;
    private int row;
    private int checkedRow;//A number used to see if a row is empty
    private int direction = 1;//To track whether the piece is moving right or left
    private float movingCounter;//A timer to see if it should move
    private bool onTop = true;

    public float movingDelay;

    void Awake()
    {
        board = FindObjectOfType<Board>();//Since the piece is a prefab, public variables won't work and it needs to find the board once it enter the scene.  Hey, thanks for reading this long comment! :)
    }

    void Start()
    {
        column = (int)transform.position.x;//Figuring out it's position
        row = (int)transform.position.y;
    }

    void Update()
    {
        movingCounter += Time.deltaTime;//Add on the slice of a second since the last frame.
        if (movingCounter > movingDelay && onTop)//If a certain amount of time has passed
        {
            StrafePiece();
        }
    }

    public int FindTheDifference()
    {
        return row - FindBottom();
    }

    public void Fall(int highRow)
    {
        if(onTop && Board.isInputEnabled)
        {
            board.PlaceBlock(column, row, column, (row - highRow), this.gameObject);//Putting the piece in the right place
            onTop = false;//Marking the piece as no longer on top
        }
    }

    void StrafePiece()
    {//This code could probably be cleaned up a bit >.>
        if ((column + direction) > board.width - 1 || (column + direction) < 0)//If the pice is at the edge of the board
        {
            direction *= -1;//Change the direction
        }

        board.PlaceBlock(column, row, column + direction, row, this.gameObject);//move piece to the right
        column += direction;//Update the column
        movingCounter = 0;//reset the timer
    }

    int FindBottom()
    {
        int checkFromTop = board.height - 4;
        while (board.gameGrid[column, checkFromTop] == null)//  checkFromTop == 0)//If the row is not empty
        {
           
            checkFromTop--;//try the one below
            //dont let the counter dip below zero
            if (checkFromTop == 0)
            {
                return checkFromTop;
            }
        }
        //LevelEnd logic not working
        //if (board.gameGrid[column, checkFromTop] != null)
        //{
        //    LevelEnd();
        //}
        return checkFromTop + 1;

        // old Find bottom method. Could be helpful in making new method work.
        //while (board.gameGrid[column, checkedRow] != null)//If the row is not empty
        //{
        //    checkedRow++;//try the one above
        //    if (checkedRow > (board.height - 3))//If the game is about to break
        //    {
        //        LevelEnd();
        //        break;
        //    }
        //}
        //return checkedRow;
    }

    private void LevelEnd()
    {
        Time.timeScale = 0;
        board.gameOver.SetActive(true);//Bring up the game over screen
        onTop = false;
        Board.isInputEnabled = false;
        Board.isPauseEnabled = false;
    }
}