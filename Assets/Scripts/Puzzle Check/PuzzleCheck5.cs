using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck5 : MonoBehaviour
{
    public Raycast checkingPuzzle5;

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Piece 5")
        {
            checkingPuzzle5.check5 = 1;
        }
    }
}
