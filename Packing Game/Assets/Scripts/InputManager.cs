using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public Block[] activeBlocks;
    public Board board;
    public Text moneyText;
    public float pieceAcceleration = .99f;
    public float musicAcceleration = .05f;
    public AudioSource musicSource;

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
            MainAction(blockBottoms);
        }

        if (Input.GetKeyDown(KeyCode.S)) //Skip Piece
        {
            //Rearrange
            board.ReorderBlock(activeBlocks);

            //Destroy and create
            //foreach (Block block in activeBlocks)
            //{
            //    block.Destroy();
            //}
            //board.SpawnNewPiece();

            //Play a disapointing sound
            FindObjectOfType<AudioManager>().Play("BoxDrop");
            board.score = board.score - 4;
            moneyText.text = "Money\nEarned: " + board.score;
        }
    }

    void MainAction(List<int> blockBottoms)
    {
        FindRestingPlace(blockBottoms);
        FindObjectOfType<AudioManager>().Play("BoxDrop");
        board.score = board.score + 3;
        moneyText.text = "Money\nEarned: " + board.score;
        board.movingDelay *= pieceAcceleration; //Sppeds up piece every time submit is pressed
        musicSource.pitch += musicAcceleration;
        if (!board.isFilled())
        {
            board.SpawnNewPiece();
        }
        else
        {
            ScoreDisplay.UpdateTotalMoney(board.score);
            ScoreDisplay.UpdateHighScore(board.score);
        }
    }

    public void FindRestingPlace(List<int> blockBottoms)
    {
        //Finds the Highest row for each block and adds it to the List
        foreach (Block block in activeBlocks)
        {
            blockBottoms.Add(block.FindTheDifference());
        }
        //Finds the highest row of all blocks
        int highestRow = Math.Min(Math.Min(blockBottoms[0], blockBottoms[1]), blockBottoms[2]);
        //Each block falls the same number of spaces
        CallFall(highestRow);
        
    }

    private void CallFall(int highestRow)
    {
        foreach (Block block in activeBlocks)
        {
            block.Fall(highestRow);
        }
    }
}
