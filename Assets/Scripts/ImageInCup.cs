using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageInCup : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Water1")
        {
            Debug.Log("Test");
        }
    }
}
