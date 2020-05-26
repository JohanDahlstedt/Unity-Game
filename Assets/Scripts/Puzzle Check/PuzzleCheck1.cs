using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck1 : MonoBehaviour
{
    public Raycast checkingPuzzle1;

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Piece 1")
        {
            checkingPuzzle1.check1 = 1;
        }
    }
}
