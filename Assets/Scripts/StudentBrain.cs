using System;
using UnityEngine;

public class StudentBrain : MonoBehaviour
{
    public EmoteController emoteController;
    
    public enum StudentState
    {
        Idle,
        Learning,
        Attentive,
        BurntOut
    }

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
}
