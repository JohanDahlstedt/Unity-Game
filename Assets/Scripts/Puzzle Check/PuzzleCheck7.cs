using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck7 : MonoBehaviour
{
    public Raycast checkingPuzzle7;

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Piece 7")
        {
            checkingPuzzle7.check7 = 1;
        }
    }
}
