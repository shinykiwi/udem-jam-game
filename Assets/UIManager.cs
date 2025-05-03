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
    }

    public void toGameScene()
    {
        upgradePanel.SetActive(false);
        upgradeButton.gameObject.SetActive(true);
    }
    
    
    
}
