using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;
    
    [SerializeField] private Image popupImage;
    [SerializeField] private TextMeshProUGUI headlineText;
    [SerializeField] private TextMeshProUGUI bodyText;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setPopup(PopupItem item)
    {
        popupImage.sprite = item.sprite;
        headlineText.text = item.headlineText;
        bodyText.text = item.bodyText;
    }
}
