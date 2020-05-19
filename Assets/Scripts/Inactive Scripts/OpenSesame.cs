using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSesame : MonoBehaviour
{
    public Key keyScript;

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "LockedDoor1" && keyScript.GotKey > 0)
        {
            Debug.Log("Press E To Open The Door");
        }

        if (collision.gameObject.tag == "LockedDoor1" && keyScript.GotKey > 0 && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(collision.gameObject);
            Debug.Log("Pretend The Door Was Opened And Not Destroyed Cuz We Havn't Added An Animation");
        }

        if (collision.gameObject.tag == "LockedDoor1" && keyScript.GotKey < 1)
        {
            Debug.Log("Door Is Locked");
        }
    }
}
