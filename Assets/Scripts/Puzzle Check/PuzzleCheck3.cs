using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck3 : MonoBehaviour
{
    public Raycast checkingPuzzle3;

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Piece 3")
        {
            checkingPuzzle3.check3 = 1;
        }
    }
}

