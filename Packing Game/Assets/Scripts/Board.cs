using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    //Please put private or otherwise not inspector editable variable here :)
    [HideInInspector] public GameObject[,] allTiles;//The array that keeps track of where all objects are

    public GameObject tromino;//The piece
    public int width;//width and height of the board
    public int height;
    public float movingDelay;

    void Start()
    {
        allTiles = new GameObject[width, height];//Making the array the appropriate size
        SpawnNewPiece();
    }

    public void SpawnNewPiece()
    {
        allTiles[0, height - 1] = tromino;//Putting the piece in the top left of the array
        GameObject square = Instantiate(tromino, new Vector2(0, height - 1), Quaternion.identity);//putting the piece in the top left of the screen
        square.GetComponent<Piece>().movingDelay = movingDelay;//Telling the piece what the moving delay is currently
    }

    public void PlacePiece(int oldColumn, int oldRow, int column, int row, GameObject piece)
    {
        allTiles[oldColumn, oldRow] = null;
        allTiles[column, row] = piece;
        piece.transform.position = new Vector2(column, row);
    }
}
