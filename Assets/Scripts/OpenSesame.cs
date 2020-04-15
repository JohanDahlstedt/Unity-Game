using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSesame : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LockedDoor1")
        {
            Debug.Log("Hit Door 1");
            collision.gameObject.transform.Rotate(0f, 90f, 0f);
            collision.gameObject.transform.position = new Vector3(2.9f, 7.47f, 16.82f);
        }

        if (collision.gameObject.tag == "LockedDoor2")
        {
            Destroy(collision.gameObject);
            //collision.gameObject.transform.Rotate(0f, 90f, 0f);
            //collision.gameObject.transform.position = new Vector3(Idk yet, Idk yet, Idk yet);
        }

        if (collision.gameObject.tag == "LockedDoor3")
        {
            Destroy(collision.gameObject);
            //collision.gameObject.transform.Rotate(0f, 90f, 0f);
            //collision.gameObject.transform.position = new Vector3(Idk yet, Idk yet, Idk yet);
        }

        if (collision.gameObject.tag == "LockedDoor4")
        {
            Destroy(collision.gameObject);
            //collision.gameObject.transform.Rotate(0f, 90f, 0f);
            //collision.gameObject.transform.position = new Vector3(Idk yet, Idk yet, Idk yet);
        }

        if (collision.gameObject.tag == "LockedDoor5")
        {
            Destroy(collision.gameObject);
            //collision.gameObject.transform.Rotate(0f, 90f, 0f);
            //collision.gameObject.transform.position = new Vector3(Idk yet, Idk yet, Idk yet);
        }
    }
}
