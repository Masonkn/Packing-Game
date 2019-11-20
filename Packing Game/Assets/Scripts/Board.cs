using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject floorTile;
    public GameObject pauseButton;

    public Spawning piece;
    public int width;//width and height of the board
    public int height;
    public float movingDelay;
    public int score;
    public static bool isInputEnabled = true;

    private GameObject newTile;

    internal void SpawnNewPiece()
    {
        piece.CreateNew();
    }

    public static bool isPauseEnabled = true;

    private bool unPaused; //aka playing


    void Start()
    {
        unPaused = true;
        gameGrid = new GameObject[width, height];//Making the array the appropriate size
        piece.CreateNew();
        pauseButton.SetActive(true);
        BuildBoundingBox();
        BuildBoundingSides();
        LayFloorTiles();
        LevelEnd(false);

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

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score:" + score); //Instantiates score counter.
    }

    public void PlaceBlock(int oldColumn, int oldRow, int column, int row, GameObject block)
    {
        gameGrid[oldColumn, oldRow] = null;
        gameGrid[column, row] = block;
        block.transform.position = new Vector2(column, row);
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

