using System;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    
    [SerializeField] UpgradeItem upgradeItem;
    Button button;

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
}
