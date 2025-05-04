using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    [SerializeField] UpgradeItem upgradeItem;
    Button button;
    [SerializeField] Upgrade[] lockedUpgrades;
    
    
    public static float scaleFactor = 1.2f;
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
            upgrade.spawn();
        }
    }

    bool hovering = false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * scaleFactor, duration).SetEase(Ease.OutBack);   
        hovering = true;
    }
    

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, duration).SetEase(Ease.InOutSine);
        hovering = false;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
    
    void Update()
    {
        if (hovering)
            transform.localEulerAngles = new Vector3(Mathf.Sin(Time.time), Mathf.Cos(Time.time), 0)*30;

    }

    void spawn()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.localScale = Vector3.zero;
        rect.DOScale(1.15f, 0.25f).SetEase(Ease.OutQuad)
            .OnComplete(() => {
                rect.DOScale(1f, 0.15f).SetEase(Ease.InOutQuad);
            });    }
}