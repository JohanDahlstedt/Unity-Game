using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Inventory inventory;
    public CharacterController controller;
    public float speed = 12f;

    void Update()
    {
        InteractRayCast();
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    //Pick up on Collision + E
    /*void OnTriggerStay(Collider collision)                
    {
        if (collision.gameObject.name == "Key1" && Input.GetKeyDown(KeyCode.E))
        {
            IInventoryItem item = collision.GetComponent<IInventoryItem>();
            inventory.AddItem(item);
        }
    }*/

    //Pick up on Raycast + E
    void InteractRayCast()                  
    {
        Vector3 playerPosition = transform.position;
        Vector3 forwardDirection = transform.forward;

        Ray interactionRay = new Ray(playerPosition, forwardDirection);
        RaycastHit interactionRayHit;
        float interactionRayLength = 20.0f;

        Vector3 interactionRayEndpoint = forwardDirection * interactionRayLength;
        Debug.DrawLine(playerPosition, interactionRayEndpoint);

        bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);
        if (hitFound)
        {
            GameObject hitGameobject = interactionRayHit.transform.gameObject;
            string hitFeedback = hitGameobject.name;

            if (hitGameobject.name == "Key1" && Input.GetKeyDown(KeyCode.E))
            {
                IInventoryItem item = hitGameobject.GetComponent<IInventoryItem>();
                inventory.AddItem(item);
            }
        }
    }
}

