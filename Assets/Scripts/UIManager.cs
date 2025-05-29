using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform classRoomUI;
    
    [SerializeField] GameObject upgradePanel;
    
    [SerializeField] FocusPoints focusPoints;
    
    public static UIManager instance;

    public void Awake()
    {
        instance = this;
    }

  

    public void toUpgradePage()
    {
        upgradePanel.SetActive(true);
        classRoomUI.gameObject.SetActive(false);
        TabManager.instance.resetTab();
        SoundManager.PlaySound(SoundManager.SoundType.POPUPOPEN);
        StudentBrain.isPaused = true;
        focusPoints.SetFocusPoints(GameManager.Instance.FocusPoints);
        
    }

    public void toGameScene()
    {
        upgradePanel.SetActive(false);
        classRoomUI.gameObject.SetActive(true);
        SoundManager.PlaySound(SoundManager.SoundType.POPUPCLOSE);
        StudentBrain.isPaused = false;
    }
}
