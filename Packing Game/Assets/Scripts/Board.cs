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
    public GameObject quitButton;
    public GameObject boundingBlock;

    public Spawning piece;
    public int width;//width and height of the board
    public int height;
    public float movingDelay;
    public int Score;
    public static bool isInputEnabled = true;
    public static bool isPauseEnabled = true;

    private bool unPaused; //aka playing


    void Start()
    {
        unPaused = true;
        gameGrid = new GameObject[width, height];//Making the array the appropriate size
        SpawnNewPiece();
        BuildBoundingBox();
    }

    void BuildBoundingBox()
    {
        for (int i = 0; i < width; i++)
        {
            Debug.Log("I'm here!");
            GameObject.Instantiate(boundingBlock, new Vector2(i, -1), Quaternion.identity);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score:" + Score); //Instantiates score counter.
    }

    public void Update()
    { 

        if (isPauseEnabled)
        {
            if (Input.GetButtonDown("Pause"))
            {
                Pause();
            }
        }
        else if (isInputEnabled)
        {
            if (Input.GetButtonDown("Submit"))
            {
                Score++;
            }
        }
    }

    public void SpawnNewPiece()
    {
        piece.CreateNew();
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
            quitButton.SetActive(true);
        }
        else
        {
            unPaused = true;
            Time.timeScale = 1;
            pauseMenu.SetActive(false); //Put down the pause screen
            isInputEnabled = true;
            quitButton.SetActive(false);

        }

    }

}

