using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Prefabs
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private Image popupImage;
        [SerializeField] private TextMeshProUGUI headlineText;
        [SerializeField] private TextMeshProUGUI bodyText;
    
        public void setPopup(PopupItem item)
        {
            Time.timeScale = 0;
            popupImage.sprite = item.sprite;
            headlineText.text = item.headlineText;
            bodyText.text = item.bodyText;
        }

        
        
        public void closePopup()
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }
}
