using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-1000)]
public class GameManager : MonoBehaviour
{
    
    //Disable on build
    [SerializeField] public bool debuggerMode = false;

    [SerializeField] private StatsContainer sc;
    

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

        students = GameObject.FindObjectsByType<Student>(FindObjectsSortMode.None);
    }
    
    
    // Points
    private int _focusPoints;
    
    // Stats
    private float _engagement;
    private float _comprehension;
    private float _burnout;
    
    
    // Events
    public event Action<int> OnFocusPointsChanged;
    

    public void Purchase(Upgrade upgrade)
    {
        UpgradeItem upgradeItem = upgrade.getUpgradeItem();
        
        if (FocusPoints >= upgradeItem.cost)
        {

            FocusPoints -= upgradeItem.cost;
            sc.Engagement.Value += upgradeItem.engagementGain;
            sc.Comprehension.Value += upgradeItem.comprehensionGain;
            sc.Burnout.Value += upgradeItem.burnoutGain;
            SoundManager.PlaySound(SoundManager.SoundType.PURCHASE);
            upgrade.onPurchase();
            
        } else {
            SoundManager.PlaySound(SoundManager.SoundType.ERROR);
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
    
    // Number of attentive, learning, burnout students
    private int attentiveStudents;
    private int learningStudents;
    private int burnoutStudents;
    
    public event Action<float> OnAttentiveStudentsChanged;
    public event Action<float> OnLearningStudentsChanged;
    public event Action<float> OnBurnedOutStudentsChanged;

    public int AttentiveStudents
    {
        get => attentiveStudents;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater than or equal to 0.");
            attentiveStudents = value;
            OnAttentiveStudentsChanged?.Invoke(value);
        }
    }

    public int LearningStudents
    {
        get => learningStudents;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater than or equal to 0.");
            }
            learningStudents = value;
            OnLearningStudentsChanged?.Invoke(value);
        }
    }

    public int BurnoutStudents
    {
        get => burnoutStudents;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be greater than or equal to 0.");
            }
            burnoutStudents = value;
            OnBurnedOutStudentsChanged?.Invoke(value);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Update()
    {

        if (debuggerMode)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
            
                FocusPoints+=1;
                //PopupManager.Instance.TestPopup();
            }
        
            if (Input.GetKeyDown(KeyCode.I))
            {
                sc.Engagement.Value += 0.1f;
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                sc.Comprehension.Value += 0.1f;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                sc.Burnout.Value += 0.1f;
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                string text = "PROGRESS REPORT"; 
            
                foreach (Student  student in students)
                {
                    text += "\n" + student.name + ": " + student.getState();
                }
            
                Debug.Log(text);
            }
        }
        
    }
}
