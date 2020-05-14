using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Inventory inventory;
    public Transform theDestination;
    public Transform slot1;
    public Transform slot2;
    public Transform slot3;
    public Transform slot4;
    public Transform slot5;
    public Transform slot6;
    public Transform slot7;
    public Transform slot8;
    public Transform slot9;

    public Transform start1;
    public Transform start2;
    public Transform start3;
    public Transform start4;
    public Transform start5;
    public Transform start6;
    public Transform start7;
    public Transform start8;
    public Transform start9;

    public Transform letterpos;

    bool carrying;
    bool carryingPuzzle;

    GameObject holding;
    public GameObject letter;

    public float interactionRayLength = 10.0f;

    void Update()
    {
        InteractRayCast();

        if (Input.GetKeyDown(KeyCode.L) && !carrying && !carryingPuzzle)
        {
            letter.gameObject.transform.position = theDestination.position;
            letter.gameObject.transform.rotation = theDestination.rotation;
            letter.gameObject.transform.Rotate(0f, 90f, 90f);
            letter.gameObject.transform.parent = GameObject.Find("Destination").transform;
            letter.gameObject.GetComponent<Rigidbody>().useGravity = false;
            letter.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(waitswitch1());
        }

        if (Input.GetKeyDown(KeyCode.L) && carrying)
        {
            letter.gameObject.transform.position = letterpos.position;
            letter.gameObject.transform.rotation = letterpos.rotation;
            letter.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            letter.GetComponent<Rigidbody>().useGravity = true;
            letter.GetComponent<BoxCollider>().enabled = true;
            letter.gameObject.transform.parent = null;
            StartCoroutine(waitswitch2());
        }
    }

    void InteractRayCast()
    {
        Vector3 playerPosition = transform.position;
        Vector3 forwardDirection = transform.forward;

        Ray interactionRay = new Ray(playerPosition, forwardDirection);
        RaycastHit interactionRayHit;

        Vector3 interactionRayEndpoint = forwardDirection * interactionRayLength;

        bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);
        if (hitFound)
        {        
            GameObject hitGameobject = interactionRayHit.transform.gameObject;
            string hitFeedback = hitGameobject.name;

            //Add Objects to Inventory
            if (hitGameobject.name == "Key1" && Input.GetKeyDown(KeyCode.E))
            {
                IInventoryItem item = hitGameobject.GetComponent<IInventoryItem>();
                inventory.AddItem(item);
            }

            if (hitGameobject.name == "Wrench" && Input.GetKeyDown(KeyCode.E))
            {
                IInventoryItem item = hitGameobject.GetComponent<IInventoryItem>();
                inventory.AddItem(item);
            }

            if (hitGameobject.name == "Candle" && Input.GetKeyDown(KeyCode.E))
            {
                IInventoryItem item = hitGameobject.GetComponent<IInventoryItem>();
                inventory.AddItem(item);
            }

            //Pickup Objects
            if (hitGameobject.tag == "Puzzle" && Input.GetKeyDown(KeyCode.E) && !carrying && !carryingPuzzle)
            {
                hitGameobject.gameObject.transform.position = theDestination.position;
                hitGameobject.gameObject.transform.rotation = theDestination.rotation;
                hitGameobject.gameObject.transform.Rotate(90f, 180f, 0f);
                hitGameobject.gameObject.transform.parent = GameObject.Find("Destination").transform;
                hitGameobject.gameObject.GetComponent<Rigidbody>().useGravity = false;
                hitGameobject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                hitGameobject.gameObject.transform.gameObject.tag = "Holding";
                hitGameobject.gameObject.layer = 2;
                holding = GameObject.FindWithTag("Holding");
                StartCoroutine(waitswitch3());
            }

            //Dropping each piece
            if (Input.GetKeyDown(KeyCode.E) && carryingPuzzle && hitGameobject.name == "Slot 1")
            {
                holding.gameObject.transform.gameObject.tag = "Puzzle";    
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                holding.gameObject.transform.position = slot1.position;
                holding.gameObject.transform.rotation = slot1.rotation;
                StartCoroutine(waitswitch4());
            }
            if (Input.GetKeyDown(KeyCode.E) && carryingPuzzle && hitGameobject.name == "Slot 2")
            {
                holding.gameObject.transform.gameObject.tag = "Puzzle";
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                holding.gameObject.transform.position = slot2.position;
                holding.gameObject.transform.rotation = slot2.rotation;
                StartCoroutine(waitswitch4());
            }
            if (Input.GetKeyDown(KeyCode.E) && carryingPuzzle && hitGameobject.name == "Slot 3")
            {
                holding.gameObject.transform.gameObject.tag = "Puzzle";
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                holding.gameObject.transform.position = slot3.position;
                holding.gameObject.transform.rotation = slot3.rotation;
                StartCoroutine(waitswitch4());
            }
            if (Input.GetKeyDown(KeyCode.E) && carryingPuzzle && hitGameobject.name == "Slot 4")
            {
                holding.gameObject.transform.gameObject.tag = "Puzzle";
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                holding.gameObject.transform.position = slot4.position;
                holding.gameObject.transform.rotation = slot4.rotation;
                StartCoroutine(waitswitch4());
            }
            if (Input.GetKeyDown(KeyCode.E) && carryingPuzzle && hitGameobject.name == "Slot 5")
            {
                holding.gameObject.transform.gameObject.tag = "Puzzle";
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                holding.gameObject.transform.position = slot5.position;
                holding.gameObject.transform.rotation = slot5.rotation;
                StartCoroutine(waitswitch4());
            }
            if (Input.GetKeyDown(KeyCode.E) && carryingPuzzle && hitGameobject.name == "Slot 6")
            {
                holding.gameObject.transform.gameObject.tag = "Puzzle";
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                holding.gameObject.transform.position = slot6.position;
                holding.gameObject.transform.rotation = slot6.rotation;
                StartCoroutine(waitswitch4());
            }
            if (Input.GetKeyDown(KeyCode.E) && carryingPuzzle && hitGameobject.name == "Slot 7")
            {
                holding.gameObject.transform.gameObject.tag = "Puzzle";
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                holding.gameObject.transform.position = slot7.position;
                holding.gameObject.transform.rotation = slot7.rotation;
                StartCoroutine(waitswitch4());
            }
            if (Input.GetKeyDown(KeyCode.E) && carryingPuzzle && hitGameobject.name == "Slot 8")
            {
                holding.gameObject.transform.gameObject.tag = "Puzzle";
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                holding.gameObject.transform.position = slot8.position;
                holding.gameObject.transform.rotation = slot8.rotation;
                StartCoroutine(waitswitch4());
            }
            if (Input.GetKeyDown(KeyCode.E) && carryingPuzzle && hitGameobject.name == "Slot 9")
            {
                holding.gameObject.transform.gameObject.tag = "Puzzle";
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                holding.gameObject.transform.position = slot9.position;
                holding.gameObject.transform.rotation = slot9.rotation;
                StartCoroutine(waitswitch4());
            }

            if (Input.GetKeyDown(KeyCode.E) && carryingPuzzle && hitGameobject.tag != "Slot")
            {
                if (holding.gameObject.name == "Piece 1")
                {
                    holding.gameObject.transform.position = start1.position;
                    holding.gameObject.transform.rotation = start1.rotation;
                    holding.gameObject.transform.gameObject.tag = "Puzzle";
                    holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    holding.GetComponent<Rigidbody>().useGravity = true;
                    holding.GetComponent<BoxCollider>().enabled = true;
                    holding.gameObject.transform.parent = null;
                    holding.gameObject.layer = 0;
                    StartCoroutine(waitswitch4());
                }
                if (holding.gameObject.name == "Piece 2")
                {
                    holding.gameObject.transform.position = start2.position;
                    holding.gameObject.transform.rotation = start2.rotation;
                    holding.gameObject.transform.gameObject.tag = "Puzzle";
                    holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    holding.GetComponent<Rigidbody>().useGravity = true;
                    holding.GetComponent<BoxCollider>().enabled = true;
                    holding.gameObject.transform.parent = null;
                    holding.gameObject.layer = 0;
                    StartCoroutine(waitswitch4());
                }
                if (holding.gameObject.name == "Piece 3")
                {
                    holding.gameObject.transform.position = start3.position;
                    holding.gameObject.transform.rotation = start3.rotation;
                    holding.gameObject.transform.gameObject.tag = "Puzzle";
                    holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    holding.GetComponent<Rigidbody>().useGravity = true;
                    holding.GetComponent<BoxCollider>().enabled = true;
                    holding.gameObject.transform.parent = null;
                    holding.gameObject.layer = 0;
                    StartCoroutine(waitswitch4());
                }
                if (holding.gameObject.name == "Piece 4")
                {
                    holding.gameObject.transform.position = start4.position;
                    holding.gameObject.transform.rotation = start4.rotation;
                    holding.gameObject.transform.gameObject.tag = "Puzzle";
                    holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    holding.GetComponent<Rigidbody>().useGravity = true;
                    holding.GetComponent<BoxCollider>().enabled = true;
                    holding.gameObject.transform.parent = null;
                    holding.gameObject.layer = 0;
                    StartCoroutine(waitswitch4());
                }
                if (holding.gameObject.name == "Piece 5")
                {
                    holding.gameObject.transform.position = start5.position;
                    holding.gameObject.transform.rotation = start5.rotation;
                    holding.gameObject.transform.gameObject.tag = "Puzzle";
                    holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    holding.GetComponent<Rigidbody>().useGravity = true;
                    holding.GetComponent<BoxCollider>().enabled = true;
                    holding.gameObject.transform.parent = null;
                    holding.gameObject.layer = 0;
                    StartCoroutine(waitswitch4());
                }
                if (holding.gameObject.name == "Piece 6")
                {
                    holding.gameObject.transform.position = start6.position;
                    holding.gameObject.transform.rotation = start6.rotation;
                    holding.gameObject.transform.gameObject.tag = "Puzzle";
                    holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    holding.GetComponent<Rigidbody>().useGravity = true;
                    holding.GetComponent<BoxCollider>().enabled = true;
                    holding.gameObject.transform.parent = null;
                    holding.gameObject.layer = 0;
                    StartCoroutine(waitswitch4());
                }
                if (holding.gameObject.name == "Piece 7")
                {
                    holding.gameObject.transform.position = start7.position;
                    holding.gameObject.transform.rotation = start7.rotation;
                    holding.gameObject.transform.gameObject.tag = "Puzzle";
                    holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    holding.GetComponent<Rigidbody>().useGravity = true;
                    holding.GetComponent<BoxCollider>().enabled = true;
                    holding.gameObject.transform.parent = null;
                    holding.gameObject.layer = 0;
                    StartCoroutine(waitswitch4());
                }
                if (holding.gameObject.name == "Piece 8")
                {
                    holding.gameObject.transform.position = start8.position;
                    holding.gameObject.transform.rotation = start8.rotation;
                    holding.gameObject.transform.gameObject.tag = "Puzzle";
                    holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    holding.GetComponent<Rigidbody>().useGravity = true;
                    holding.GetComponent<BoxCollider>().enabled = true;
                    holding.gameObject.transform.parent = null;
                    holding.gameObject.layer = 0;
                    StartCoroutine(waitswitch4());
                }
                if (holding.gameObject.name == "Piece 9")
                {
                    holding.gameObject.transform.position = start9.position;
                    holding.gameObject.transform.rotation = start9.rotation;
                    holding.gameObject.transform.gameObject.tag = "Puzzle";
                    holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    holding.GetComponent<Rigidbody>().useGravity = true;
                    holding.GetComponent<BoxCollider>().enabled = true;
                    holding.gameObject.transform.parent = null;
                    holding.gameObject.layer = 0;
                    StartCoroutine(waitswitch4());
                }
            }
        }
    }

    IEnumerator waitswitch1()
    {
        yield return new WaitForSeconds(0.01f);
        carrying = true;
    }

    IEnumerator waitswitch2()
    {
        yield return new WaitForSeconds(0.01f);
        carrying = false;
    }
    IEnumerator waitswitch3()
    {
        yield return new WaitForSeconds(0.01f);
        carryingPuzzle = true;
    }
    IEnumerator waitswitch4()
    {
        yield return new WaitForSeconds(0.01f);
        carryingPuzzle = false;
    }
}
