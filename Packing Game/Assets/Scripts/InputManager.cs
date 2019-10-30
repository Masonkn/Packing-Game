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
                block.Fall();
            }
        }
    }
}
