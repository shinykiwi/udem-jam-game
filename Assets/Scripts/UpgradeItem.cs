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

    public bool isGood;
    public string upgradeName;
    public string frenchName;
    public string description;
    public string frenchDescription;
    public int cost;

    public float engagementGain;
    public float comprehensionGain;
    public float burnoutGain;


}
