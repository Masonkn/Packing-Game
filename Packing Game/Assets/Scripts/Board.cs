using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //Please put private or otherwise not inspector editable variable here :)
    [HideInInspector] public GameObject[,] allTiles;//The array that keeps track of where all objects are

    public GameObject tromino;//The piece
    public GameObject gameOver;
    public GameObject pauseMenu;
    public Piece piece;
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
        allTiles = new GameObject[width, height];//Making the array the appropriate size
        SpawnNewPiece();
        //SpawnNewPiece(0, height - 1);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score:" + Score); //Instantiates score counter.
    }

    public void Update()
    {
        //tromino.GetComponent<Block>().movingDelay = movingDelay * 0.99f;

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
        allTiles[oldColumn, oldRow] = null;
        allTiles[column, row] = block;
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
            
        }
        else
        {
            unPaused = true;
            Time.timeScale = 1;
            pauseMenu.SetActive(false); //Put down the pause screen
            isInputEnabled = true;
        }
        
    }

}
