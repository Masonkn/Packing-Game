﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private Board board;
    private int column;
    private int row;
    private int checkedRow;//A number used to see if a row is empty
    private int direction = 1;//To track whether the piece is moving right or left
    private float movingCounter;//A timer to see if it should move
    private bool onTop = true;


    public float movingDelay;

    void Start()
    {
        board = FindObjectOfType<Board>();//Since the piece is a prefab, public variables won't work and it needs to find the board once it enter the scene.  Hey, thanks for reading this long comment! :)
        column = (int)transform.position.x;//Figuring out it's position
        row = (int)transform.position.y;

    void CreateNewTromino()
    {
        board = FindObjectOfType<Board>();//For some reason this works better because the board script really wants to finish its start function first
        SpawnBlock(1, board.height - 2);
        board.gameGrid[1, board.height - 2] = board.tromino;

        int blockOne = Random.Range(0, 3); //The first block can be placed in any of the four 
        int blockTwo;
        do{
            blockTwo = Random.Range(0, 3); //The second block cannot be in the same location as the first
        } while (blockTwo == blockOne);
        
        PlaceBlocks(blockOne);
        PlaceBlocks(blockTwo);
    }

    void Update()
    {
        movingCounter += Time.deltaTime;//Add on the slice of a second since the last frame.
        if(movingCounter > movingDelay && onTop)//If a certain amount of time has passed
        {
            MoveTopPiece();
        }

        if (Input.GetButtonDown("Submit") && onTop && Board.isInputEnabled)//If space is pressed and it's on top
        {
            board.ScoreAdder();
            board.PlacePiece(column, row, column, FindBottom(), this.gameObject);//Putting the piece in the right place
            board.SpawnNewPiece();//And replacing it
            onTop = false;//Marking the piece as no longer on top
        }
    }

    void MoveTopPiece()
    {//This code could probably be cleaned up a bit >.>
        if ((column + direction) > board.width - 1 || (column + direction) < 0)//If the pice is at the edge of the board 
        {
            direction *= -1;//Change the direction
        }

        board.PlacePiece(column, row, column + direction, row, this.gameObject);//move piece to the right
        column += direction;//Update the column
        movingCounter = 0;//reset the timer
    }

    int FindBottom()
    {

        while (board.allTiles[column,checkedRow] != null)//If the row is not empty
        {
            checkedRow ++;//try the one above
            if(checkedRow > (board.height -3))//If the game is about to break
            {
                onTop = false;
                LevelEnd();
                break;
            }
        }
        board.movingDelay = 0.2f; //TODO: An attempt to reset movingDelay after a piece has been dropped.
        return checkedRow;
    }
        board.gameGrid[x,y] = board.tromino;//Putting the piece in the mostly top, left, center of the array

    void LevelEnd() //Stops time and input, brings up UI.
    {
        Time.timeScale = 0;
        board.gameOver.SetActive(true);//Brings up the game over screen
        Board.isInputEnabled = false;
        Board.isPauseEnabled = false;
    }
}
