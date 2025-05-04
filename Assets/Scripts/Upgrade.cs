using System;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    
    [SerializeField] UpgradeItem upgradeItem;
    Button button;
    [SerializeField] Upgrade[] lockedUpgrades;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Start()
    {
        button.onClick.AddListener(() => InfoManager.instance.displayUpgrade(this));
    }

    public UpgradeItem getUpgradeItem()
    {
        return upgradeItem;
    }

    public void onPurchase()
    {
        foreach (Upgrade upgrade in lockedUpgrades)
        {
            upgrade.gameObject.SetActive(true);
        }
    }
}
