using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

public class Spawning : MonoBehaviour
{
    private Board board;

    public InputManager inputManager;

    void Start()
    {
        //For some reason this works better because the board script really wants to finish its start function first
        board = FindObjectOfType<Board>();
    }

    public void CreateNew()
    {
        SpawnBlock(1, board.height - 2, 0);
        board.gameGrid[1, board.height - 2] = board.tromino;


        int blockOne = Random.Range(0, 3); //The first block can be placed in any of the four
        int blockTwo;
        do
        {
            blockTwo = Random.Range(0, 3); //The second block cannot be in the same location as the first
        } while (blockTwo != blockOne);

        PlaceBlocks(blockOne, 1);
        PlaceBlocks(blockTwo, 2);
    }

    private void PlaceBlocks(int blockNum, int spot)
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
        board.gameGrid[x, y] = board.tromino;//Putting the piece in the mostly top, left, center of the array

        GameObject block = Instantiate(board.tromino, new Vector2(x, y), Quaternion.identity);//putting the piece in the top left of the screen
        block.GetComponent<Block>().movingDelay = board.movingDelay;//Telling the piece what the moving delay is currently
        inputManager.activeBlocks[spot] = block.GetComponent<Block>();
    }
}
