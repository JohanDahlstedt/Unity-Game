using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour, IInventoryItem
{

    public int GotCandle = 0;

    public string Name
    {
        get
        {
            return "Candle";
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
        GotCandle = 1;
    }
}
