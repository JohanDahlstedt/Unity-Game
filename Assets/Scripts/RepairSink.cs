﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSink : MonoBehaviour
{

    public GameObject fakewater;
    public TurnOnWater Water;
    public GameObject WaterFlowPrcl;
    public WaterAwake waterScript;
    public Animator TapAnim;
    private bool coroutineAllowed;

    void Start()
    {
        coroutineAllowed = true;
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E) && coroutineAllowed && Water.WaterOn > 0)
        {
            StartCoroutine("FixSink");
        }

        if (coroutineAllowed && Water.WaterOn == 0)
        {
            Debug.Log("Water In The House Seems To Be Turned Off.");
        }
    }

    private IEnumerator FixSink()
    {
        coroutineAllowed = false;
        
        transform.Rotate(0f, 0f, 0f);
        yield return new WaitForSeconds(0.01f);
        WaterFlowPrcl.SetActive(true);
        TapAnim.enabled = true;
        waterScript.WaterRise = 1;

        coroutineAllowed = true;
        
    }
}
