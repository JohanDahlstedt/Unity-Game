using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck4 : MonoBehaviour
{
    public Raycast checkingPuzzle4;

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Piece 4")
        {
            checkingPuzzle4.check4 = 1;
        }
    }
}
