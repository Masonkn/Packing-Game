using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //Please put private or otherwise not inspector editable variable here :)
    [HideInInspector] public GameObject[,] allTiles;//The array that keeps track of where all objects are
    [HideInInspector] public GameObject[,] rightTile;//The array that keeps track of where all objects are

    public GameObject tromino;//The piece
    public GameObject gameOver;
    public GameObject pauseMenu;
    public int width;//width and height of the board
    public int height;
    public float movingDelay;
    public int Score;

    private bool unPaused;

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
        if(Input.GetButtonDown("Pause"))
        {
            Pause();
        }
        else if(Input.GetButtonDown("Submit"))
        {
            Score++;
        }
    }

    public void SpawnNewPiece()
    {
        allTiles[1, height - 2] = tromino;//Putting the piece in the mostly top, left, center of the array
      //  rightTile[x, y - 1] = tromino;//Putting the piece in the top left of the array
        
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
        }
        else
        {
            unPaused = true;
            Time.timeScale = 1;
            pauseMenu.SetActive(false); //Put down the pause screen
        }
        
    }

}
