using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchScript : MonoBehaviour, IInventoryItem
{

    public int GotWrench = 0;

    public string Name
    {
        get
        {
            return "Wrench";
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
        GotWrench = 1;
    }
}