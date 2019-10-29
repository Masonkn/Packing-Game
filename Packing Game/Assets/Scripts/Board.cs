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
        tromino.GetComponent<Piece>().movingDelay = movingDelay * 0.99f; //TODO: An attempt to speed up the movement of the moving block over time

        if (isPauseEnabled)
        {
            if (Input.GetButtonDown("Pause"))
            {
                Pause();
            }
        }
    }

    public void ScoreAdder() //Adds to the score whenever "Submit" key is pressed (Space).
    {
        Score++;
    }

    public void SpawnNewPiece()
    {
        //KingPiece Tromino = new KingPiece();
        //Tromino.CreateNew();
        allTiles[1, height - 2] = tromino;//Putting the piece in the mostly top, left, center of the array
        
        GameObject square = Instantiate(tromino, new Vector2(1, height - 2), Quaternion.identity);//putting the piece in the top left of the screen
        square.GetComponent<Piece>().movingDelay = movingDelay;//Telling the piece what the moving delay is currently
    }

    public void PlacePiece(int oldColumn, int oldRow, int column, int row, GameObject piece)
    {
        allTiles[oldColumn, oldRow] = null;
        allTiles[column, row] = piece;
        piece.transform.position = new Vector2(column, row);
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
