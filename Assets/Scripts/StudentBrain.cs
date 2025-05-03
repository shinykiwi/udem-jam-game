using System;
using UnityEngine;

public class StudentBrain : MonoBehaviour
{
    public enum StudentState
    {
        Idle,
        Learning,
        Attentive,
        BurntOut
    }
    
    private EmoteController emoteController;
    
    public EmoteController Emote { get; set; }
    
    private StudentState state;
    public StudentState State
    {
        get { return state; }
        
        private set
        {
            state = value;
            UpdateState();
        }
    }
    
    [SerializeField] private StudentData studentData;

    private void UpdateState()
    {
        switch (State)
        {
            case StudentState.Idle:
                break;
            case StudentState.Learning:
                break;
            case StudentState.Attentive:
                break;
            case StudentState.BurntOut:
                break;
            default:
                throw new NotImplementedException();
        }
    }

    // Constantly rolling the dice on whether a student might change states
    private void Update()
    {
        
    }
}
