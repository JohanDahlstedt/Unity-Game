﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    public int first;
    public int second;
    public int third;

    


    private int[] result, correctCombination;
   

    private void Start()
   
    {

       

        result = new int[] { 1, 1, 1 };
        correctCombination = new int[] { first, second, third };

        Rotate.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "Wheel1":
                result[0] = number;
                break;

            case "Wheel2":
                result[1] = number;
                break;

            case "Wheel3":
                result[2] = number;
                break;
        }
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            GameObject.FindWithTag("LockedBox1").transform.position = new Vector3(-28.175f, 7.277f, 42f);
            GameObject.FindWithTag("LockedBox1").transform.Rotate(0, 0, 90);
        }
    }
    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}