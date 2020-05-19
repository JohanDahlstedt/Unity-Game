using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSesame : MonoBehaviour
{
    public Key keyScript;
    public Collider DoorClosedColl;
    public Collider DoorOpenColl;

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && keyScript.GotKey > 0)
        {
            Debug.Log("Press E To Open The Door");
        }

        if (collision.gameObject.tag == "Player" && keyScript.GotKey > 0 && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Animator>().enabled = true;
            DoorClosedColl.enabled = false;
            DoorOpenColl.enabled = true;
            Debug.Log("Pretend The Door Was Opened And Not Destroyed Cuz We Havn't Added An Animation");
        }

        if (collision.gameObject.tag == "Player" && keyScript.GotKey < 1)
        {
            Debug.Log("Door Is Locked");
        }
    }
}
