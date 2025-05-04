using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSequence : MonoBehaviour
{
    [SerializeField] private CinemachineCamera firstCam;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private FadeToBlack fadeToBlack;
    
    private bool canPress = false;
    
    public void Play()
    {
        FadeToBlack.onFadeComplete += LoadScene;
        firstCam.enabled = false;
        StartCoroutine(PromptPlayer());
    }

    IEnumerator PromptPlayer()
    {
        yield return new WaitForSeconds(2f);
        canPress = true;
        
        // show UI
        text.DOFade(1f, 1f);
    }

    private void LoadScene()
    {
        FadeToBlack.onFadeComplete -= LoadScene;
        SceneManager.LoadScene("Main");
    }

    private void Update()
    {
        if (canPress)
        {
            if (Input.anyKeyDown)
            {
                fadeToBlack.DoFadeIn(2);
                text.enabled = false;
            }
        }
    }
}
