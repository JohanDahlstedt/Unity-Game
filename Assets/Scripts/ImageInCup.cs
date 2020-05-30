using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageInCup : MonoBehaviour
{
    public Raycast letterScript;
    public Material[] material;
    public int x;
    Renderer rend;


    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }

    void Update()
    {
        rend.sharedMaterial = material[x];
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Water1")
        {          
            StartCoroutine("CleanCup");
        }
    }
    
    public IEnumerator CleanCup()
    {
        yield return new WaitForSeconds(3);
        if (x < 1)
        {
            x++;
            letterScript.puzzleCheck1 = true;
        }
        
    }
}
