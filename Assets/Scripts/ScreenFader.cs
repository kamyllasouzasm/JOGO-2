using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenFader : MonoBehaviour
{
    CanvasGroup cg;

    void Awake() => cg = GetComponent<CanvasGroup>();

    public void SetAlpha(float value)
    {
        cg.alpha = Mathf.Clamp01(value);
    }

    public object FadeTo(float f, float f1)
    {
        throw new System.NotImplementedException();
    }
}


