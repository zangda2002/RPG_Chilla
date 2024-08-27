using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : SingleTon<UIFade>
{
    public Image fadeScreen;
    public float fadeTime = 1f;

    private IEnumerator fadeRoutine;

    public void FadeToBlack()
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(1);
        StartCoroutine(fadeRoutine);
    }

    public void FadeToClear()
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = FadeRoutine(0);
        StartCoroutine(fadeRoutine);
    }

    private IEnumerator FadeRoutine(float targetalpha)
    {
        while (!Mathf.Approximately(fadeScreen.color.a, targetalpha))
        {
            float alpha = Mathf.MoveTowards(fadeScreen.color.a, targetalpha, fadeTime * Time.deltaTime);
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, alpha);
            yield return null;
        }
    }
}
