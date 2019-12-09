using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPiece : MonoBehaviour
{
    private Board board;

    void Start()
    {
        board = FindObjectOfType<Board>();//Since the piece is a prefab, public variables won't work and it needs to find the board once it enters the scene.  Hey, thanks for reading this long comment! :)
    }

    public int FindGhostDifferenceInt()
    {
        return 0;
    }
    public void PlaceGhostBlock(int column, int row, GameObject block) //Same as PlaceBlock but it does not update the gameGrid array.
    {
        block.transform.position = new Vector2(column, row);
    }


}
