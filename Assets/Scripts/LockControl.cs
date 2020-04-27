﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    public int first;
    public int second;
    public int third;
    public int CheckIfOpened = 0;

    private int[] result, correctCombination;
   

    public GameObject key;

    private void Start()
   
    {

       

        result = new int[] { 6, 6, 6 };
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


        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && CheckIfOpened == 0)
        {

            GameObject.FindWithTag("LockedBox1").transform.position = new Vector3(-19.93f, 2.49f, -1.23f);

            GameObject.FindWithTag("LockedBox1").transform.Rotate(0, 0, 90);
            CheckIfOpened = 1;

            key.SetActive(true);

        }
    }
    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}