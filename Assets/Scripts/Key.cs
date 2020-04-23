using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInventoryItem
{
<<<<<<< Updated upstream
=======
    public int GotKey = 0;
    //Test

>>>>>>> Stashed changes
    public string Name
    {
        get
        {
            return "Key";
        }
    }

    public Sprite _Image;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
