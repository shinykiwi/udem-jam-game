using System;
using System.Collections;
using System.Numerics;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class EmoteController : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;

    [Header("Emotes")] 
    [SerializeField] private Sprite learning;
    [SerializeField] private Sprite unhappy;
    [SerializeField] private Sprite happy;
    [SerializeField] private Sprite laughing;
    [SerializeField] private Sprite bored;
    [SerializeField] private Sprite question;
    
    private bool isEmoting = false;

    private Vector3 initialTextLocation;

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
        text.enabled = false;
        initialTextLocation = text.transform.position;
    }

    private void TextAnimation(string s)
    {
        text.text = s;
        float duration = 3f;
        text.enabled = true;
        text.transform.DOMoveY(text.transform.position.y - 1f, duration);
        Tween tween = text.DOFade(0f, duration);
        tween.OnComplete(ResetText);
    }

    private void ResetText()
    {
        text.enabled = false;
        text.color = Color.white;
        text.transform.position = initialTextLocation;
    }

    private void EmoteOnce(Sprite sprite)
    {
        image.sprite = sprite;
        EmotePopupAnimationWithFade();
    }

    private void Emote(Sprite sprite)
    {
        image.sprite = sprite;
        EmotePopupAnimation();
    }
    
    public void EmoteLearning()
    {
        EmoteOnce(learning);
        TextAnimation("+1 Learning");
    }

    public void EmoteUnhappy()
    {
        EmoteOnce(unhappy);
        TextAnimation("+1 Burnt Out");
    }

    public void EmoteHappy()
    {
        EmoteOnce(happy);
        TextAnimation("+1 Engaged");
    }

    public void EmoteLaughing()
    {
        EmoteOnce(laughing);
    }

    public void EmoteBored()
    {
        EmoteOnce(bored);
        TextAnimation("+1 Focus");
    }

    public void EmoteQuestion()
    {
        Emote(question);
    }

    private void EmotePopupAnimationWithFade()
    {
        EmotePopupAnimation();
        StartCoroutine(FadeEmote());
    }
    // Emotes
    private void EmotePopupAnimation()
    {
        // Do not emote if already emoting
        if (IsEmoting) return;
        
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

    }

    // Fades the emote after a while
    IEnumerator FadeEmote(float duration = 2f)
    {
        yield return new WaitForSeconds(2f);
        
        FadeImage(duration);
        
    }

    private void FadeImage(float duration)
    {
        Tween tween = image.DOFade(0, duration);
        tween.onComplete = () =>
        {
            IsEmoting = false;
        };
    }

    public void StopEmoting()
    {
        // If not emoting, don't continue
        if (!IsEmoting) return;
        
        float duration = 0.4f;
        image.transform.DOPunchScale(Vector3.one * 1.1f, duration / 2);
        FadeImage(duration);
    }

    // Debug only
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EmoteQuestion();
        }
    }
}
