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
    public GameObject tutorialText;

    private AudioManager audioManager;

    private void Start()
    {
        activeBlocks = new Block[3];
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            MainAction();
        }

        if (Input.GetKeyDown(KeyCode.S) && !(board.score - 4 < 0)) //Skip Piece 
        {
            //Rearrange
            board.ReorderBlock(activeBlocks);
            
            //Play a disapointing sound
            FindObjectOfType<AudioManager>().Play("BoxDrop");
            board.score = board.score - 4;
            moneyText.text = "Money\nEarned: " + board.score;
        }
    }

    public void SkipPiece()
    {
        if (!(board.score - 4 < 0)) //Skip Piece 
        {
            //Rearrange
            board.ReorderBlock(activeBlocks);

            //Play a disapointing sound
            FindObjectOfType<AudioManager>().Play("BoxDrop");
            board.score = board.score - 4;
            moneyText.text = "Money\nEarned: " + board.score;
        }
    }

    public void MainAction()
    {
        List<int> blockBottoms = new List<int>();
        if (Board.isInputEnabled)
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
            Destroy(tutorialText);

            GameObject[] ghosts = GameObject.FindGameObjectsWithTag("destroyus");
            foreach (GameObject ghost in ghosts)
                Destroy(ghost);
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
