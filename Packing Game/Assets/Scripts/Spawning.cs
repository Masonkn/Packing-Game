using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System;

public class Spawning : MonoBehaviour
{
    private Board board;

    public InputManager inputManager;
    public GameObject ghostPiece;

    void Start()
    {
        //For some reason this works better because the board script really wants to finish its start function first
        board = FindObjectOfType<Board>();
    }
    //void Update()
    //{
    //    ghostblock = FindObjectOfType<Block>();
    //}

    public void CreateNew()
    {
        SpawnBlock(1, board.height - 2, 0);
        //board.gameGrid[1, board.height - 2] = board.tromino;

        int blockOne = UnityEngine.Random.Range(0, 4); //The first block can be placed in any of the four
        int blockTwo;
        do {
            blockTwo = UnityEngine.Random.Range(0, 4); //The second block cannot be in the same location as the first
        } while (blockTwo == blockOne);

        PlaceBlocks(blockOne, 1);
        PlaceBlocks(blockTwo, 2);
    }

    private void PlaceBlocks(int blockNum, int spot)//Creates a piece
    {
        switch (blockNum)
        {
            case 0:
                SpawnBlock(1, board.height - 1, spot); //top middle
                break;
            case 1:
                SpawnBlock(1, board.height - 3, spot); //bottom middle
                break;
            case 2:
                SpawnBlock(0, board.height - 2, spot); //middle left
                break;
            case 3:
                SpawnBlock(2, board.height - 2, spot); //middle right
                break;
        }
    }

    private void SpawnBlock(int x, int y, int spot)
    {
        board.gameGrid[x, y] = board.tromino;//Putting the piece in the (mostly) top, left, center of the array
        GameObject block = Instantiate(board.tromino, new Vector2(x, y), Quaternion.identity);//putting the piece in the top left of the screen
        block.GetComponent<Block>().movingDelay = board.movingDelay;//Telling the piece what the moving delay is currently
        block.layer = 2;
        inputManager.activeBlocks[spot] = block.GetComponent<Block>();
        SpawnGhostBlock(x, y);
    }

    public void SpawnGhostBlock(int column, int row) //This needs to spawn on the findrestingplace location everytime a piece moves.
    {
        GameObject.Instantiate(ghostPiece, new Vector2(column, ghostPiece.GetComponent<GhostPiece>().FindGhostDifferenceInt()), Quaternion.identity);
    }
}
