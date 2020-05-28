using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    public int first;
    public int second;
    public int third;
    public int CheckIfOpened = 0;
    public AudioSource Open;
    public AudioSource OpenCreak;
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

            GameObject.FindWithTag("LockedBox1").GetComponent<Animator>().enabled = true;
            GameObject.FindWithTag("LockedBox1").GetComponent<BoxCollider>().enabled = false;
            CheckIfOpened = 1;

            key.SetActive(true);
            Open.Play();
            OpenCreak.Play();

        }
    }
    private void OnDestroy()
    {
        Rotate.Rotated -= CheckResults;
    }
}