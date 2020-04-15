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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);      
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "Key1" && Input.GetKeyDown(KeyCode.E))
        {
            IInventoryItem item = collision.GetComponent<IInventoryItem>();
            inventory.AddItem(item);
        }
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }*/ 
}

