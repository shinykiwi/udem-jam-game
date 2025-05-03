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
    
    // Points
    private int focusPoints;
    
    // Stats
    private float engagement;
    private float comprehension;
    private float burnout;
    
    // Events
    public event Action<int> OnFocusPointsChanged;
    public event Action<float> OnEngagementChanged;
    public event Action<float> OnComprehensionChanged;
    public event Action<float> OnBurnoutChanged;

    public int FocusPoints
    {
        get => focusPoints;
        set
        {
            focusPoints = Mathf.Max(0, focusPoints + value);
            OnFocusPointsChanged?.Invoke(focusPoints);
        } 
    }
    
    public float Engagement
    {
        get => engagement;
        private set
        {
            engagement = Mathf.Clamp(engagement + value, 0f, 1);
            OnEngagementChanged?.Invoke(engagement);
        }
    }

    public float Comprehension
    {
        get => comprehension;
        set
        {
            comprehension = Mathf.Clamp(comprehension + value, 0f, 1);
            OnComprehensionChanged?.Invoke(comprehension);
        } 
    }

    public float Burnout
    {
        get => burnout;
        set
        {
            burnout = Mathf.Clamp(burnout + value, 0f, 1);
            OnBurnoutChanged?.Invoke(burnout);
        } 
    }
    
    // Number of attentive, learning, burnout students
    public int attentiveStudents;
    public int learningStudents;
    public int burnoutStudent;
    
}
