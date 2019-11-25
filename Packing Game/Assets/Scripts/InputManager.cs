using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [HideInInspector]public Block[] activeBlocks;
    public Board board;
    private AudioManager audioManager;

    private void Start()
    {
        activeBlocks = new Block[3];
    }

    void Update()
    {
        List<int> blockBottoms = new List<int>();
        if (Input.GetButtonDown("Submit") && Board.isInputEnabled)
        {
            FindRestingPlace(blockBottoms);
            FindObjectOfType<AudioManager>().Play("BoxDrop");
            board.score++;
            board.movingDelay *= .99f; //Sppeds up piece every time submit is pressed
            if (!board.isFilled())
            {
                board.SpawnNewPiece();
            }
            else
            {
                ScoreDisplay.UpdateScore(board.score);
            }
        }
    }

    void FindRestingPlace(List<int> blockBottoms)
    {
        //Finds the Highest row for each block and adds it to the List
        foreach (Block block in activeBlocks)
        {
            blockBottoms.Add(block.FindTheDifference());
        }
        //Finds the highest row of all blocks
        int highestRow = Math.Min(Math.Min(blockBottoms[0], blockBottoms[1]), blockBottoms[2]);
        //Each block falls the same number of spaces
        foreach (Block block in activeBlocks)
        {
            block.Fall(highestRow);
        }
        
    }
}
