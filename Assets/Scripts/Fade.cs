using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Image blackFade;
    public Image letterFade;
    public Image fadeNarrative;
    public Raycast winning;
    bool startOtherFade;

    void Start()
    {
        blackFade.canvasRenderer.SetAlpha(0.0f);
        letterFade.canvasRenderer.SetAlpha(0.0f);
        
        StartCoroutine(fadeOutNarrative());
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
            StartCoroutine(Quit());
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
        Debug.Log("blackfade should start");
        blackFade.CrossFadeAlpha(1, 2, false);
        yield return null;
    }

    IEnumerator fadeOutNarrative()
    {
        fadeNarrative.CrossFadeAlpha(0, 3, true);
        yield return null;
    }
    IEnumerator Quit()
    {
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(0);
    }
}
