using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;




public class Piece : MonoBehaviour
{
    private Board board;

    public void CreateNew()
    {
        board = FindObjectOfType<Board>();//For some reason this works better because the board script really wants to finish its start function first
        SpawnBlock(1, board.height - 2);
        board.allTiles[1, board.height - 2] = board.tromino;

        int blockOne = Random.Range(0, 3); //The first block can be placed in any of the four 
        int blockTwo;
        do{
            blockTwo = Random.Range(0, 3); //The second block cannot be in the same location as the first
        } while (blockTwo != blockOne);
        
        PlaceBlocks(blockOne);
        //PlaceBlocks(blockTwo);
    }

    private void PlaceBlocks(int blockNum)
    {
        switch (blockNum)
        {
            case 0:
                SpawnBlock(1, board.height - 1); //top middle
                break;
            case 1:
                SpawnBlock(1, board.height - 3); //bottom middle
                break;
            case 2:
                SpawnBlock(0, board.height - 2); //middle left
                break;
            case 3:
                SpawnBlock(2, board.height - 2); //middle right
                break;
        }
    }

    private void SpawnBlock(int x, int y)
    {
        board.allTiles[x,y] = board.tromino;//Putting the piece in the mostly top, left, center of the array

        GameObject square = Instantiate(board.tromino, new Vector2(x,y), Quaternion.identity);//putting the piece in the top left of the screen
        square.GetComponent<Block>().movingDelay = board.movingDelay;//Telling the piece what the moving delay is currently
    }
}
