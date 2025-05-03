using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EmoteController : MonoBehaviour
{
    [SerializeField] private Image image;

    private bool isEmoting = false;

    public bool IsEmoting
    {
        get => isEmoting;
        set
        {
            isEmoting = value;
            
            if (isEmoting)
            {
               image.enabled = true; 
            }
            else
            {
                image.enabled = false;
                image.color = Color.white;
            }
        }
    }
    
    private void Start()
    {
        // Should not be emoting to begin with
        IsEmoting = false;
    }

    // Emotes
    private void EmotePopupAnimation()
    {
        IsEmoting = true;
        
        float scale = 0.2f;
        
        image.transform.localScale = new Vector3(scale, scale, scale);
        image.transform.DOScale(Vector3.one * 1.1f, 0.4f);

        float y = image.transform.position.y;
        
        Tween tween = image.transform.DOMoveY(y + 1f, 0.2f);
        tween.onComplete = (() =>
        {
            image.transform.DOMoveY(y, 0.2f);
        });

        StartCoroutine(FadeEmote());

    }

    // Fades the emote after a while
    IEnumerator FadeEmote()
    {
        yield return new WaitForSeconds(2f);
        
        Tween tween = image.DOFade(0, 2f);
        tween.onComplete = () =>
        {
            IsEmoting = false;
        };
    }

    // Debug only
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EmotePopupAnimation();
        }
    }
}
