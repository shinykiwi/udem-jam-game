using System;
using UnityEngine;

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
    
    // Stats
    public float engagement;
    public float comprehension;
    public float burnout;
    
    // Number of attentive, learning, burnout students
    public int attentiveStudents;
    public int learningStudents;
    public int burnoutStudent;
}
