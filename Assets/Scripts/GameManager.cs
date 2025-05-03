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
    public int focusPoints;
    
    // Stats
    public float engagement;
    public float comprehension;
    public float burnout;
    
    // Number of attentive, learning, burnout students
    public int attentiveStudents;
    public int learningStudents;
    public int burnoutStudent;

    public Action<int> onFocusChange;
    public Action<float> onEngagementChange;
    public Action<float> onComprehensionChange;
    public Action<float> onBurnoutChange;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            addFocusPoint(10);
            addBurnout(0.2f);
            addComprehension(0f);
        }
    }

    public void addFocusPoint(int value)
    {
        focusPoints = Mathf.Max(0, focusPoints + value);
        onFocusChange?.Invoke(focusPoints);
    }
    public void addEngagement(float value)
    {
        engagement = Mathf.Clamp(engagement + value, 0f, 1);
        onEngagementChange?.Invoke(engagement);
    }
    
    public void addComprehension(float value)
    {
        comprehension = Mathf.Clamp(comprehension + value, 0f, 1);
        onComprehensionChange?.Invoke(comprehension);
    }
    
    public void addBurnout(float value)
    {
        burnout = Mathf.Clamp(burnout + value, 0f, 1);
        onBurnoutChange?.Invoke(burnout);
    }
    
}
