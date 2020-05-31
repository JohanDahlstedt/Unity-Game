using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public Transform cupEnd1;

    public Transform puzzlePos;
    public Transform FirstPersonPlayer;

    public int check1 = 0;
    public int check2 = 0;
    public int check3 = 0;
    public int check4 = 0;
    public int check5 = 0;
    public int check6 = 0;
    public int check7 = 0;
    public int check8 = 0;
    public int check9 = 0;

    public int winCheck = 0;

    public Transform letterpos;

    bool carrying;
    bool carryingPuzzle;
    bool carryingCup;

    bool stopZoom;
    bool dontLag;
    public bool allowedRotate;

    public bool puzzleCheck1;
    public bool puzzleCheck2;

    GameObject holding;
    GameObject lettershow;

    public GameObject letter1;
    public GameObject letter2;
    public GameObject letter3;

    public GameObject inventoryLetter;

    public float interactionRayLength = 10.0f;

    public MouseLook yPos;
    public PlayerMovement iAmSpeed;

    void Start()
    {
        StartCoroutine(AddToInv());
    }

    void Update()
    {
        InteractRayCast();
        
        if (check1 == 1 && check2 == 1 && check3 == 1 && check4 == 1 && check5 == 1 && check6 == 1 && check7 == 1 && check8 == 1 && check9 == 1)
        {
            puzzleCheck2 = true;
        }

        //Show Letter 1
        if (Input.GetKeyDown(KeyCode.L) && !carrying && !carryingPuzzle && !carryingCup && !puzzleCheck1 && !puzzleCheck2)
        {
            letter1.gameObject.transform.gameObject.tag = "LetterShow";
            letter1.gameObject.transform.position = theDestination.position;
            letter1.gameObject.transform.rotation = theDestination.rotation;
            letter1.gameObject.transform.Rotate(0f, 0f, 0f);
            letter1.gameObject.transform.parent = GameObject.Find("Destination").transform;
            letter1.gameObject.GetComponent<Rigidbody>().useGravity = false;
            letter1.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            lettershow = GameObject.FindWithTag("LetterShow");
            StartCoroutine(waitswitch1());
        }
        //Show Letter 2
        if (Input.GetKeyDown(KeyCode.L) && !carrying && !carryingPuzzle && !carryingCup && puzzleCheck1 && !puzzleCheck2)
        {
            letter2.gameObject.transform.gameObject.tag = "LetterShow";
            letter2.gameObject.transform.position = theDestination.position;
            letter2.gameObject.transform.rotation = theDestination.rotation;
            letter2.gameObject.transform.Rotate(0f, 0f, 0f);
            letter2.gameObject.transform.parent = GameObject.Find("Destination").transform;
            letter2.gameObject.GetComponent<Rigidbody>().useGravity = false;
            letter2.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            lettershow = GameObject.FindWithTag("LetterShow");
            StartCoroutine(waitswitch1());
        }

        //Show Letter 3
        if (Input.GetKeyDown(KeyCode.L) && !carrying && !carryingPuzzle && !carryingCup && !puzzleCheck1 && puzzleCheck2)
        {
            letter3.gameObject.transform.gameObject.tag = "LetterShow";
            letter3.gameObject.transform.position = theDestination.position;
            letter3.gameObject.transform.rotation = theDestination.rotation;
            letter3.gameObject.transform.Rotate( 0f, 0f, 0f);
            letter3.gameObject.transform.parent = GameObject.Find("Destination").transform;
            letter3.gameObject.GetComponent<Rigidbody>().useGravity = false;
            letter3.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            lettershow = GameObject.FindWithTag("LetterShow");
            StartCoroutine(waitswitch1());
        }

        //Show after all Puzzles are done
        if (Input.GetKeyDown(KeyCode.L) && !carrying && !carryingPuzzle && !carryingCup && puzzleCheck1 && puzzleCheck2)
        {
            winCheck = 1;
        }

        //Hide Letter
        if (Input.GetKeyDown(KeyCode.L) && carrying)
        {
            lettershow.gameObject.transform.position = letterpos.position;
            lettershow.gameObject.transform.rotation = letterpos.rotation;
            lettershow.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            lettershow.GetComponent<Rigidbody>().useGravity = true;
            lettershow.GetComponent<BoxCollider>().enabled = true;
            lettershow.gameObject.transform.parent = null;
            lettershow.gameObject.transform.gameObject.tag = "LetterHide";
            StartCoroutine(waitswitch2());
        }
    }

    void OnTriggerStay(Collider collision)
    {
        //collision check on Sink
        if (collision.gameObject.tag == "Sink")
        {
            if (Input.GetKeyDown(KeyCode.E) && carryingCup)
            {
                holding.gameObject.transform.gameObject.tag = "Cup";
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                holding.gameObject.transform.position = cupEnd1.position;
                holding.gameObject.transform.rotation = cupEnd1.rotation;
                StartCoroutine(waitswitch6());
            }
        }
        if (collision.gameObject.tag != "Sink")
        {
            if (Input.GetKeyDown(KeyCode.E) && carryingCup)
            {
                holding.gameObject.transform.gameObject.tag = "Cup";
                holding.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                holding.GetComponent<Rigidbody>().useGravity = true;
                holding.GetComponent<BoxCollider>().enabled = true;
                holding.gameObject.transform.parent = null;
                holding.gameObject.layer = 0;
                StartCoroutine(waitswitch6());
            }
        }
    }

    void InteractRayCast()
    {
        //Finding item name via raycast
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

            //Move Closer to puzzle
            if (!dontLag && hitGameobject.tag == "Code" && Input.GetKeyDown(KeyCode.E))
            {         
                transform.parent = null;
                transform.parent = GameObject.Find("puzzlePos").transform;
                transform.position = puzzlePos.position;
                yPos.normalPos = 2;
                iAmSpeed.speed = 0;
                allowedRotate = true;
                dontLag = true;
                StartCoroutine(waitswitch7());
            }

            if (stopZoom && Input.GetKeyDown(KeyCode.Q))
            {
                transform.parent = null;
                transform.parent = GameObject.Find("First Person Player").transform;
                transform.position = FirstPersonPlayer.position;
                iAmSpeed.speed = 1.6f;
                yPos.normalPos = 1;
                allowedRotate = false;
                dontLag = false;
                StartCoroutine(waitswitch8());
            }

            //Pickup Objects
            if (hitGameobject.tag == "Puzzle" && Input.GetKeyDown(KeyCode.E) && !carrying && !carryingPuzzle && !carryingCup)
            {
                hitGameobject.gameObject.transform.position = theDestination.position;
                hitGameobject.gameObject.transform.rotation = theDestination.rotation;
                hitGameobject.gameObject.transform.Rotate(0f, 180f, 0f);
                hitGameobject.gameObject.transform.parent = GameObject.Find("Destination").transform;
                hitGameobject.gameObject.GetComponent<Rigidbody>().useGravity = false;
                hitGameobject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                hitGameobject.gameObject.transform.gameObject.tag = "Holding";
                hitGameobject.gameObject.layer = 2;
                holding = GameObject.FindWithTag("Holding");
                StartCoroutine(waitswitch3());
            }
            if (hitGameobject.tag == "Cup" && Input.GetKeyDown(KeyCode.E) && !carrying && !carryingPuzzle && !carryingCup)
            {
                hitGameobject.gameObject.transform.position = theDestination.position;
                hitGameobject.gameObject.transform.rotation = theDestination.rotation;
                hitGameobject.gameObject.transform.Rotate(70f, 160f, 0f);
                hitGameobject.gameObject.transform.parent = GameObject.Find("Destination").transform;
                hitGameobject.gameObject.GetComponent<Rigidbody>().useGravity = false;
                hitGameobject.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                hitGameobject.gameObject.transform.gameObject.tag = "Holding";
                hitGameobject.gameObject.layer = 2;
                holding = GameObject.FindWithTag("Holding");
                StartCoroutine(waitswitch5());
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

            //Check to see if you outside the puzzle
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

                //Where they will go if outside
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
    
    //Waiting time so you don't accidently double click
    IEnumerator waitswitch1()
    {
        yield return new WaitForSeconds(0.01f);
        carrying = true;
    }

    IEnumerator waitswitch2()
    {
        yield return new WaitForSeconds(0.2f);
        carrying = false;
    }
    IEnumerator waitswitch3()
    {
        yield return new WaitForSeconds(0.01f);
        carryingPuzzle = true;
    }
    IEnumerator waitswitch4()
    {
        yield return new WaitForSeconds(0.2f);
        carryingPuzzle = false;
    }
    IEnumerator waitswitch5()
    {
        yield return new WaitForSeconds(0.01f);
        carryingCup = true;
    }
    IEnumerator waitswitch6()
    {
        yield return new WaitForSeconds(0.2f);
        carryingCup = false;
    }
    IEnumerator waitswitch7()
    {
        yield return new WaitForSeconds(0.2f);
        stopZoom = true;
    }
    IEnumerator waitswitch8()
    {
        yield return new WaitForSeconds(0.2f);
        stopZoom = false;
    }
    IEnumerator AddToInv()
    {
        yield return new WaitForSeconds(0.01f);
        IInventoryItem item = inventoryLetter.GetComponent<IInventoryItem>();
        inventory.AddItem(item);
    }
}
