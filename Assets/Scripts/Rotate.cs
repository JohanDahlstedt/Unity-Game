﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    public AudioSource wheelClick;
    private int numberShown;
    public Raycast rotationAllowed;

    void Start()
    {
        coroutineAllowed = true;
        numberShown = 1;
    }

    private void OnMouseOver()
    {
        if (coroutineAllowed && rotationAllowed.allowedRotate && Input.GetKeyDown(KeyCode.E))
        {
            wheelClick.Play();
            StartCoroutine("RotateWheel");
        }
    }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(0f, 3f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;

        numberShown += 1;

        if (numberShown > 9)
        {
            numberShown = 0;
        }
        Rotated(name, numberShown);
    }
}