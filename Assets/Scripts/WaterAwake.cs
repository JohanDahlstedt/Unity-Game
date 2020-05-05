using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAwake : MonoBehaviour
{
    public int WaterRise = 0;

    public GameObject fakewater;

    public Transform target;
    public float speed;

    void Update()
    {

        if (WaterRise > 0)
        {
            float step = speed * Time.deltaTime;
            fakewater.transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
