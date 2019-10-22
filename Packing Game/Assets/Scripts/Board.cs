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
    
    void Start()
    {
        allTiles = new GameObject[width, height];//Making the array the appropriate size
        allTiles[0, height-1] = tromino;//Putting the piece in the top left of the array
        GameObject square = Instantiate(tromino, new Vector2(0, height-1), Quaternion.identity);//putting the piece in the top left of the screen
    }
}
