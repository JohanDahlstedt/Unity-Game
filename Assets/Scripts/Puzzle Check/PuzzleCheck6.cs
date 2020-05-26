using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck6 : MonoBehaviour
{
    public Raycast checkingPuzzle6;

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Piece 6")
        {
            checkingPuzzle6.check6 = 1;
        }
    }
}