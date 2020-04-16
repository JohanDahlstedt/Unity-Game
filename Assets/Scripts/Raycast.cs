using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Inventory inventory;

    void Update()
    {
        InteractRayCast();
    }

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
            Debug.Log(hitFeedback);

            if (hitGameobject.name == "Key1" && Input.GetKeyDown(KeyCode.E))
            {
                IInventoryItem item = hitGameobject.GetComponent<IInventoryItem>();
                inventory.AddItem(item);
            }
        }
    }
}
