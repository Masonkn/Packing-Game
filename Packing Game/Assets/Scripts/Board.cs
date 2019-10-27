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
    public int width;//width and height of the board
    public int height;
    public float movingDelay;
    public int Score;

    private bool isPaused;

    void Start()
    {

        allTiles = new GameObject[width, height];//Making the array the appropriate size
        SpawnNewTromino();
        //SpawnNewPiece(0, height - 1);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score:" + Score);
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

    public void SpawnNewPiece(int x, int y)
    {
        allTiles[x, y] = tromino;//Putting the piece in the top left of the array
      //  rightTile[x, y - 1] = tromino;//Putting the piece in the top left of the array
        
        GameObject square = Instantiate(tromino, new Vector2(x, y), Quaternion.identity);//putting the piece in the top left of the screen
        square.GetComponent<Piece>().movingDelay = movingDelay;//Telling the piece what the moving delay is currently
    }

    public void SpawnNewTromino()
    {
        SpawnNewPiece(0, height - 1); //Center Block
        SpawnNewPiece(1, height - 1); //Right Block
        SpawnNewPiece(0, height - 2); //Top Block
        //GameObject square = Instantiate(tromino, new Vector2(0, height - 1), Quaternion.identity);//putting the piece in the top left of the screen
        //square.GetComponent<Piece>().movingDelay = movingDelay;//Telling the piece what the moving delay is currently
    }

    public void PlacePiece(int oldColumn, int oldRow, int column, int row, GameObject piece)
    {
        allTiles[oldColumn, oldRow] = null;
        allTiles[column, row] = piece;
        piece.transform.position = new Vector2(column, row);
    }
    public void Pause()
    {
        if (isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
        
    }
}
