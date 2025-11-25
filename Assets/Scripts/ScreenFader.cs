using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenFader : MonoBehaviour
{
    private CanvasGroup cg;

    void Awake()
    {
        cg = GetComponent<CanvasGroup>();
    }

    
    public IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = cg.alpha;
        float time = 0;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            cg.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            yield return null;
        }

        cg.alpha = targetAlpha; 
    }
}



