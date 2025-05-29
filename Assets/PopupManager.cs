using Prefabs;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance;
    [SerializeField] private Popup popupPrefab;
    [SerializeField] private PopupItem testPopup;
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

    public void CreatePopup(PopupItem popupItem)
    {
        
        var popup = Instantiate(popupPrefab, transform);
        popup.setPopup(popupItem);
    }

    public void TestPopup()
    {
        CreatePopup(testPopup);
    }

    
}
