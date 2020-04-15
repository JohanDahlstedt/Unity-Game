using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public bool mFaded = false;
    public float Duration = 0.4f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("1");
            var canvGroup = GetComponent<CanvasGroup>();

            StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));
            mFaded = !mFaded;
        }
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);
            yield return null;
        }
    }
}
