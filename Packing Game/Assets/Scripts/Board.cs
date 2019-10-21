using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private GameObject[,] allTiles;
    private Vector2 tempPosition;


    public GameObject tromino;
    public int width = 10;
    public int height = 16;
    
    void Start()
    {
        allTiles = new GameObject[width, height];
        allTiles[0, height-1] = tromino;
        GameObject square = Instantiate(tromino, new Vector2(0, height-1), Quaternion.identity);
    }
}
