using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageInCup : MonoBehaviour
{
    public Material start;
    public Material end;
    float duration = 2.0f;
    Renderer rend;


    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = start;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Water1")
        {
            StartCoroutine("CleanCup");
        }
    }

    public IEnumerator CleanCup()
    {
        yield return new WaitForSeconds(3);
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.Lerp(start, end, lerp);
    }
}
