using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

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

    IEnumerator RollDiceContinuously()
    {
        while (true)
        {
            yield return new WaitForSeconds(studentData.secondsBetweenRolls);
            
            RollLearningDice();
            RollAttentiveDice();
            RollBurntOutDice();
            
        }
    }

    private void RollLearningDice()
    {
        // ex. 0.2 * 0.9 = 0.18
        float learningRoll = studentData.learningTendency * GameManager.Instance.comprehension;

        // ex. check if a random float is less than or equal to 0.18, thus passing the check
        // like rolling a die
        if (Random.Range(0, 1) <= (learningRoll))
        {
            // If it passes, change the state to learning
            State = StudentState.Learning;
        }
    }

    private void RollAttentiveDice()
    {
        float attentiveRoll = studentData.attentiveTendency * GameManager.Instance.engagement;

        if (Random.Range(0,1) <= attentiveRoll)
        {
            State = StudentState.Attentive;
        }
    }

    private void RollBurntOutDice()
    {
        float burnoutRoll = studentData.burnoutTendency * GameManager.Instance.burnout;

        if (Random.Range(0,1) <= burnoutRoll)
        {
            State = StudentState.BurntOut;
        }
    }
}
