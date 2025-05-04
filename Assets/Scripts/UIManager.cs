using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button upgradeButton;
    [SerializeField] GameObject upgradePanel;

    public void toUpgradePage()
    {
        upgradePanel.SetActive(true);
        upgradeButton.gameObject.SetActive(false);
        SoundManager.PlaySound(SoundManager.SoundType.POPUPOPEN);
    }

    public void toGameScene()
    {
        upgradePanel.SetActive(false);
        upgradeButton.gameObject.SetActive(true);
        SoundManager.PlaySound(SoundManager.SoundType.SWIPE);
    }

    public void selectSocial()
    {
        SoundManager.PlaySound(SoundManager.SoundType.SWIPE);
    }

    public void selectTeaching()
    {
        SoundManager.PlaySound(SoundManager.SoundType.SWIPE);
    }

    public void selectAbilities()
    {
        SoundManager.PlaySound(SoundManager.SoundType.SWIPE);
    }

    public void selectClassroom()
    {
        SoundManager.PlaySound(SoundManager.SoundType.SWIPE);
    }



}
