using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI nameText;
    [SerializeField]TextMeshProUGUI descriptionText;
    [SerializeField]TextMeshProUGUI costText;
    [SerializeField]Button purchaseButton;
    
    public static InfoManager instance;

    public void Awake()
    {
        instance = this;
    }
    
    public void displayInfo(Tab tab)
    {
        nameText.text = tab.tabName;
        descriptionText.text = tab.description;
        
        purchaseButton.gameObject.SetActive(false);
        costText.gameObject.SetActive(false);

    }

    public void displayUpgrade(Upgrade upgrade)
    {
        UpgradeItem upgradeItem = upgrade.getUpgradeItem();
        print(upgrade.name);
        print(upgradeItem.name);
        nameText.text = upgradeItem.upgradeName;
        descriptionText.text = upgradeItem.description;
        costText.text = "-"  + upgradeItem.cost.ToString() + " Focus";
        
        purchaseButton.gameObject.SetActive(true);
        costText.gameObject.SetActive(true);
        
    }
}
