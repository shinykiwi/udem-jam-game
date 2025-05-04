using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    private Image image;
    [SerializeField] private bool fadeOutOnStart = false;
    [SerializeField] private bool fadeInOnStart = false;
    
    private Color black = Color.black;
    private Color clear;
    
    public delegate void OnFadeComplete();
    public static OnFadeComplete onFadeComplete;

    private void Start()
    {
        clear = new Color(black.r, black.g, black.b, 0);
        image = GetComponentInChildren<Image>();
        if (fadeOutOnStart)
        {
            DoFadeOut();
        }
        else if (fadeInOnStart)
        {
            DoFadeIn();
        }
    }

    public void DoFadeIn(float duration = 1f)
    {
        image.color = clear;
        Tween tween = image.DOFade(1f, duration);
        tween.OnComplete(() => onFadeComplete?.Invoke());
    }

    public void DoFadeOut(float duration = 1f)
    {
        image.color = Color.black;
        Tween tween = image.DOFade(0f, duration);
        tween.OnComplete(() => onFadeComplete?.Invoke());
    }

    public void Toggle()
    {
        image.enabled = !image.enabled;
    }
}