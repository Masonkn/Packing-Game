using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector]public Block[] activeBlocks;

    private void Start()
    {
        activeBlocks = new Block[3];
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            foreach (Block block in activeBlocks)
            {
                if (block != null)//This was lazy debugging.  Not needed for trominoes only dominoes and less
                {
                    block.Fall();
                }
            }
        }
    }
}
