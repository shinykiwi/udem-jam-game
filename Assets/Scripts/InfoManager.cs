using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI nameText;
    [SerializeField]TextMeshProUGUI descriptionText;
    [SerializeField]TextMeshProUGUI costText;
    [SerializeField]Button purchaseButton;

    [SerializeField] PointVariable focusPoints;
    public static InfoManager instance;

    [SerializeField] StatsContainer sc;


    public Action<Upgrade> OnUpgradePurchased;
    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
        //OnUpgradePurchased+= GameManager.Instance.Purchase;
    }
    
    public void displayInfo(Tab tab)
    {
        if (Language.isEnglish)
        {
            nameText.text = tab.tabName;
            descriptionText.text = tab.description;
        } else
        {
            nameText.text = tab.frenchName;
            descriptionText.text = tab.frenchDescription;
        }

        purchaseButton.gameObject.SetActive(false);
        costText.gameObject.SetActive(false);

    }


    public void displayUpgrade(Upgrade upgrade)
    {
        UpgradeItem upgradeItem = upgrade.getUpgradeItem();

        if (Language.isEnglish)
        {
            nameText.text = upgradeItem.upgradeName;
            descriptionText.text = upgradeItem.description;
            costText.text = "-" + upgradeItem.cost.ToString() + " Focus";
        } else
        {
            nameText.text = upgradeItem.frenchName;
            descriptionText.text = upgradeItem.frenchDescription;
            costText.text = "-" + upgradeItem.cost.ToString() + " Focus";
        }
        
        purchaseButton.onClick.RemoveAllListeners();
        //When purchase sucessfull
        purchaseButton.onClick.AddListener(() =>
        {
            OnUpgradePurchased?.Invoke(upgrade);
            UpgradeItem upgradeItem = upgrade.getUpgradeItem();
            if (focusPoints.Value >= upgradeItem.cost)
            {

                focusPoints.Value -= upgradeItem.cost;
                sc.Engagement.Value += upgradeItem.engagementGain;
                sc.Comprehension.Value += upgradeItem.comprehensionGain;
                sc.Burnout.Value += upgradeItem.burnoutGain;
                SoundManager.PlaySound(SoundManager.SoundType.PURCHASE);
                upgrade.onPurchase();

            }
            else
            {
                SoundManager.PlaySound(SoundManager.SoundType.ERROR);
            }
            purchaseButton.interactable = !upgrade.purchased;
            if (upgrade.purchased)
                purchaseButton.transform.DOShakeRotation(0.1f, strength: new Vector3(0,0,15), vibrato: 2, randomness: 90f).SetEase(Ease.OutBounce);
            
        });

        
        ColorBlock colorBlock = purchaseButton.colors;
        if (focusPoints.Value >= upgradeItem.cost)
        {
            colorBlock.normalColor = Color.green;
            colorBlock.highlightedColor = Color.green;
            
            purchaseButton.interactable = true;
        }
        else
        {
            colorBlock.normalColor = Color.gray;
            colorBlock.highlightedColor = Color.gray;
            colorBlock.selectedColor = Color.gray;
            purchaseButton.interactable = false;

        }
        
        purchaseButton.colors = colorBlock;
        
        purchaseButton.gameObject.SetActive(true);
        costText.gameObject.SetActive(true);
        purchaseButton.interactable = !upgrade.purchased;
        SoundManager.PlaySound(SoundManager.SoundType.SELECT);


    }
}
