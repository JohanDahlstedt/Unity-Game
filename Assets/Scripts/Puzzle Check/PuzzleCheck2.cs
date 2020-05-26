using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck2 : MonoBehaviour
{
    public Raycast checkingPuzzle2;

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Piece 2")
        {
            checkingPuzzle2.check2 = 1;
        }
    }
}
