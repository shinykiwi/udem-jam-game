using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button upgradeButton;
    [SerializeField] GameObject upgradePanel;
    
    public static UIManager instance;

    public void Awake()
    {
        instance = this;
    }

  

    public void toUpgradePage()
    {
        upgradePanel.SetActive(true);
        upgradeButton.gameObject.SetActive(false);
        TabManager.instance.resetTab();
        SoundManager.PlaySound(SoundManager.SoundType.POPUPOPEN);
        StudentBrain.isPaused = true;
        
    }

    public void toGameScene()
    {
        upgradePanel.SetActive(false);
        upgradeButton.gameObject.SetActive(true);
        SoundManager.PlaySound(SoundManager.SoundType.POPUPCLOSE);
        StudentBrain.isPaused = false;
    }

    public void selectSocial()
    {
        SoundManager.PlaySound(SoundManager.SoundType.SELECT);
    }

    public void selectTeaching()
    {
        SoundManager.PlaySound(SoundManager.SoundType.SELECT);
    }

    public void selectAbilities()
    {
        SoundManager.PlaySound(SoundManager.SoundType.SELECT);
    }

    public void selectClassroom()
    {
        SoundManager.PlaySound(SoundManager.SoundType.SELECT);
    }



}
