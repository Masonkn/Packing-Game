﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    //Please put private or otherwise not inspector editable variable here :)
    [HideInInspector] public GameObject[,] gameGrid;//The array that keeps track of where all objects are

    public GameObject tromino;//The piece
    public GameObject gameOver;
    public GameObject pauseMenu;
    public GameObject mainMenuButton;
    public GameObject boundingBlock;
    public GameObject boundingBlockleft;
    public GameObject boundingBlockright;
    public GameObject truckCornerleft;
    public GameObject truckCornerright;
    public GameObject floorTile;
    public GameObject pauseButton;
    public GameObject TruckFront;


    public Spawning piece;
    public int width;//width and height of the board
    public int height;
    public float movingDelay;
    public int score;
    public static bool isInputEnabled = true;
    public static bool isPauseEnabled = true;

    private GameObject newTile;
    private bool unPaused; //aka playing


    internal void SpawnNewPiece()
    {
        piece.CreateNew();
    }  

    void Start()
    {
        unPaused = true;
        gameGrid = new GameObject[width, height];//Making the array the appropriate size
        piece.CreateNew();
        BuildBoundingBox();
        BuildBoundingSides();
        BuildTruckFront();
        LayFloorTiles();
        LevelEnd(false);
        BuildButtons();
    }
    //public int TellGhostPieceDistance()
    //{
    //    int realheight = height - 4;
    //    return realheight - piece.Find;
    //}


    private void BuildButtons() //TODO: this isn't working for some reason...
    {
        GameObject.Instantiate(pauseButton, new Vector2(0,0), Quaternion.identity);
    }

    public bool isFilled()
    {
        var isfilled = false;
        int fillLine = height - 4;
        for (int i = 0; i < width; i++)
        {
            if (gameGrid[i, fillLine] != null)
            {
                LevelEnd(true);
                isfilled = true;
            }
        }
        return isfilled;
    }
    
    public void LevelEnd(bool levelEnd)
    {
        if (levelEnd)
        {
            Time.timeScale = 0;
            FindObjectOfType<AudioManager>().Play("CloseDoor");
            FindObjectOfType<AudioManager>().Play("TruckFull");

        }
        else
        {
            Time.timeScale = 1;
        }
        gameOver.SetActive(levelEnd);//Bring up the game over screen
        mainMenuButton.SetActive(levelEnd);
        isInputEnabled = !levelEnd;
        isPauseEnabled = !levelEnd;
    }
    
    void BuildTruckFront()
    {
        GameObject.Instantiate(TruckFront, new Vector2((width - width / 2)-.5f, -3.9f), Quaternion.identity);
    }

    void BuildBoundingBox()
    {
        for (int i = 0; i < width; i++)
        {
            GameObject.Instantiate(boundingBlock, new Vector2(i, -1), Quaternion.identity);
        }
    }

    void BuildBoundingSides()
    {
        for (int i = 0; i < height-3; i++)
        {
            GameObject.Instantiate(boundingBlockleft, new Vector2(-1, i), Quaternion.identity);
            GameObject.Instantiate(boundingBlockright, new Vector2(width , i ), Quaternion.identity);
        }
        GameObject.Instantiate(truckCornerleft, new Vector2(-1, -1), Quaternion.identity);
        GameObject.Instantiate(truckCornerright, new Vector2(width, -1), Quaternion.identity);
    }

    void LayFloorTiles()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height-3; y++)
            {
                newTile = GameObject.Instantiate(floorTile, new Vector2(x, y), Quaternion.identity);
                newTile.layer = 0;
            }
        }
    }
    public void ReorderBlock(Block[] activeBlocks)
    {
        activeBlocks[0].Reorder(1, height - 2);

        int blockOne = Random.Range(0, 4); //The first block can be placed in any of the four
        int blockTwo;
        do
        {
            blockTwo = Random.Range(0, 4); //The second block cannot be in the same location as the first
        } while (blockTwo == blockOne);

        PlaceFinder(blockOne, 1, activeBlocks);
        PlaceFinder(blockTwo, 2, activeBlocks);
    }

    private void PlaceFinder(int blockNum, int spot, Block[] activeBlocks)//Creates a piece
    {
        switch (blockNum)
        {
            case 0:
                activeBlocks[spot].Reorder(1, height - 1);
                break;
            case 1:
                activeBlocks[spot].Reorder(1, height - 3);
                break;
            case 2:
                activeBlocks[spot].Reorder(0, height - 2);
                break;
            case 3:
                activeBlocks[spot].Reorder(2, height - 2);
                break;
        }
    }

    public void PlaceBlock(int oldColumn, int oldRow, int column, int row, GameObject block)
    {
        gameGrid[oldColumn, oldRow] = null;
        gameGrid[column, row] = block;
        block.transform.position = new Vector2(column, row);
        //PlaceGhostBlock(column,tromino.FindGhost);
    }


    public void Pause()
    {
        if (unPaused)
        {
            unPaused = false;
            Time.timeScale = 0;
            pauseMenu.SetActive(true); //Bring up pause screen
            isInputEnabled = false;
            mainMenuButton.SetActive(true);
        }
        else
        {
            unPaused = true;
            Time.timeScale = 1;
            pauseMenu.SetActive(false); //Put down the pause screen
            isInputEnabled = true;
            mainMenuButton.SetActive(false);

        }

    }

    //public void LevelEnd(bool levelEnd)
    //{
    //    if (levelEnd)
    //    {
    //        Time.timeScale = 0;
    //    }
    //    else
    //    {
    //        Time.timeScale = 1; 
    //    }
    //    gameOver.SetActive(levelEnd);//Bring up the game over screen
    //    mainMenuButton.SetActive(levelEnd);
    //    isInputEnabled = !levelEnd;
    //    isPauseEnabled = !levelEnd;
    //}

}

