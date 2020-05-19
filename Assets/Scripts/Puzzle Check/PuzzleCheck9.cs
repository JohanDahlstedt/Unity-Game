using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck9 : MonoBehaviour
{
    public Raycast checkingPuzzle9;

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Piece 9")
        {
            checkingPuzzle9.check9 = 1;
        }
    }
}
