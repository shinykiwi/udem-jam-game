using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    
    [SerializeField] UpgradeItem upgradeItem;
    
    [SerializeField]private Image upgradeImage;
    void Start()
    {
        upgradeImage.sprite = upgradeItem.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
