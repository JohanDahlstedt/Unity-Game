using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnWater : MonoBehaviour
{
    public WrenchScript wrenchScript;

    private bool coroutineAllowed;

    public int WaterOn = 0;
    public AudioSource WaterFlow;
    public AudioSource WaterHammer;
    public AudioSource WrenchSqueak;

    void Start()
    {
        coroutineAllowed = true;
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E) && coroutineAllowed && wrenchScript.GotWrench > 0)
        {
            if (WaterOn == 0)
            {
                 WaterFlow.Play();
                 WrenchSqueak.Play();
                 WaterHammer.Play();
            }
            
            StartCoroutine("FixSink");
            
        }

        if (coroutineAllowed && wrenchScript.GotWrench == 0)
        {
            Debug.Log("You Need Some Object To Turn This Wheel");
        }
    }

    private IEnumerator FixSink()
    {
        coroutineAllowed = false;

        WaterOn = 1;

        Debug.Log("Water Is Now Turned On");
       
        transform.Rotate(0f, 15f, 0f);
        yield return new WaitForSeconds(0.01f);

        coroutineAllowed = true;
    }
}
