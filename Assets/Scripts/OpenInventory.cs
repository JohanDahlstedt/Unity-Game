using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
    public Image blackFade;
    public Image letterFade;
    public Raycast winning;
    bool startOtherFade;

    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(0.0f);
        letterFade.canvasRenderer.SetAlpha(0.0f);
    }

    void Update()
    {
        if (winning.winCheck == 1)
        {
            StartCoroutine(fadeInLetter());
        }

        if (startOtherFade)
        {
            StartCoroutine(fadeInBlack());
        }
    }

    IEnumerator fadeInLetter()
    {
        letterFade.CrossFadeAlpha(1, 0.5f, false);
        yield return new WaitForSeconds(1.5f);
        startOtherFade = true;
    }

    IEnumerator fadeInBlack()
    {
        blackFade.CrossFadeAlpha(1, 2, false);
        yield return null;
    }
}
