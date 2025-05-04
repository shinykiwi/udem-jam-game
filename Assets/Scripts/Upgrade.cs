using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    [SerializeField] UpgradeItem upgradeItem;
    Button button;
    [SerializeField] Upgrade[] lockedUpgrades;
    
    
    private static Vector3 originalScale;
    public static float scaleFactor = 1.1f;
    public static float duration = 0.2f;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(originalScale * scaleFactor, duration).SetEase(Ease.OutBack);    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
