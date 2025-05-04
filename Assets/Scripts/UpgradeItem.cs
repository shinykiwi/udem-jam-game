using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeItem", menuName = "ScriptableObjects/UpgradeItem")]
public class UpgradeItem : ScriptableObject
{
    public enum Category
    {
        Social,
        Teaching,
        Ability
    }
    public Sprite sprite;   
    
    public string upgradeName;
    public Category category;
    public string upgradeDescription;
    public int cost;
    public Upgrade[] coUpgradeItems;

    public float engagementGain;
    public float comprehensionGain;
    public float burnoutGain;


}
