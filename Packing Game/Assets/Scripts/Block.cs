using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    public int column;
    public int row;
    public float movingDelay;
    public GameObject ghostPiece;
    public Sprite[] boxes;


    private Board board;
    private GameObject child;
    private GhostBlock childScript;
    private int checkedRow;//A number used to see if a row is empty
    private int direction = 1;//To track whether the piece is moving right or left
    private float movingCounter;//A timer to see if it should move
    private bool onTop = true;
    private int rand;


    void Awake()
    {
        board = FindObjectOfType<Board>();//Since the piece is a prefab, public variables won't work and it needs to find the board once it enters the scene.  Hey, thanks for reading this long comment! :)
    }

    void Start()
    {
        column = (int)transform.position.x;//Figuring out it's position
        row = (int)transform.position.y;
        //GameObject.Instantiate(ghostPiece, new Vector2(column, ghostPiece.GetComponent<GhostBlock>().FindGhostDifferenceInt(board, column)), Quaternion.identity, this.gameObject.transform); //ghostPiece.GetComponent<GhostBlock>().FindGhostDifferenceInt(board))

    }

    void Update()
    {
        movingCounter += Time.deltaTime;//Add on the slice of a second since the last frame.
        if (movingCounter > movingDelay && onTop)//If a certain amount of time has passed
        {
            StrafePiece();
            //ghostPiece.GetComponent<GhostBlock>().PlaceGhostBlock(column, this.gameObject, board);
        }
    }
    
    public void Reorder(int newColumn, int newRow)
    {
        board.PlaceBlock(column, row, newColumn, newRow, this.gameObject);
        row = newRow;
        column = newColumn;
        direction = 1;
    }
    
    public int FindTheDifference()
    {
        return row - FindBottom();
    }

    public void Fall(int highestRow)
    {
        if(onTop)
        {
            board.PlaceBlock(column, row, column, (row - highestRow), this.gameObject);//Putting the piece in the right place
            onTop = false;//Marking the piece as no longer on top
        }  
    }
    
    void StrafePiece()
    {//This code could probably be cleaned up a bit >.>
        if ((column + direction) > board.width - 1 || (column + direction) < 0)//If the pice is at the edge of the board
        {
            direction *= -1;//Change the direction
            FindObjectOfType<AudioManager>().Play("BoxChangeDirection");

        }
        board.PlaceBlock(column, row, column + direction, row, this.gameObject);//move piece to the right and left
        column += direction;//Update the column
        movingCounter = 0;//reset the timer

        GhostBlockMover();   
    }

    void GhostBlockMover()
    {
        childScript = GetComponentInChildren<GhostBlock>();
        child = childScript.gameObject;
        child.transform.position = new Vector2(column, childScript.FindGhostDifferenceInt(board, column));
    }
    public void SpriteChanger()
    {
        rand = UnityEngine.Random.Range(0, boxes.Length);
        GetComponent<SpriteRenderer>().sprite = boxes[rand];
    }

    public int FindBottom()
    {
        int checkFromTop = board.height - 4;
        if(board.gameGrid[column, checkFromTop] != null) //checking for fill line.
        {
            onTop = false;
            //board.LevelEnd(true);
        }

        while (board.gameGrid[column, checkFromTop] == null)//If the row is not empty
        {
           
            checkFromTop--;//try the one below
            //dont let the counter check below zero
            if (checkFromTop == -1)
            {
                break;
            }
        }
        return checkFromTop + 1;
    }
}