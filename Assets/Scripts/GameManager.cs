using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance { get; private set; }

    public static Student[] students;
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void Start()
    {
        InfoManager.instance.OnUpgradePurchased += Purchase;
        //focusPoints = 0;
        //engagement = 0;
        //comprehension = 0;
        //burnout = 0;
    }
    
    
    // Points
    private int _focusPoints;
    
    // Stats
    private float _engagement;
    private float _comprehension;
    private float _burnout;
    
    
    // Events
    public event Action<int> OnFocusPointsChanged;
    public event Action<float> OnEngagementChanged;
    public event Action<float> OnComprehensionChanged;
    public event Action<float> OnBurnoutChanged;


    public void Purchase(Upgrade upgrade)
    {
        UpgradeItem upgradeItem = upgrade.getUpgradeItem();
        
        if (FocusPoints >= upgradeItem.cost)
        {

            FocusPoints -= upgradeItem.cost;
            Engagement += upgradeItem.engagementGain;
            Comprehension += upgradeItem.comprehensionGain;
            Burnout += upgradeItem.burnoutGain;
            upgrade.onPurchase();
            
        }
    }
    public int FocusPoints
    {
        get => _focusPoints;
        set
        {
            _focusPoints = Mathf.Max(0, value);
            OnFocusPointsChanged?.Invoke(_focusPoints);
        } 
    }
    
    public float Engagement
    {
        get => _engagement;
        set
        {
            _engagement = Mathf.Clamp(value, 0f, 1);
            OnEngagementChanged?.Invoke(_engagement);
        }
    }

    public float Comprehension
    {
        get => _comprehension;
        set
        {
            _comprehension = Mathf.Clamp( value, 0f, 1);
            OnComprehensionChanged?.Invoke(_comprehension);
        } 
    }

    public float Burnout
    {
        get => _burnout;
        set
        {
            _burnout = Mathf.Clamp(value, 0f, 1);
            OnBurnoutChanged?.Invoke(_burnout);
        } 
    }
    
    // Number of attentive, learning, burnout students
    public int attentiveStudents;
    public int learningStudents;
    public int burnoutStudent;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Engagement +=0.1f;
            Comprehension += 0.5f;
            FocusPoints+=1;
        }
    }
}
