using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck8 : MonoBehaviour
{
    public Raycast checkingPuzzle8;

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Piece 8")
        {
            checkingPuzzle8.check8 = 1;
        }
    }
}
