﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hightlight : MonoBehaviour
{
    public Color startColor;
    public Color mouseOverColor;

    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }
}
