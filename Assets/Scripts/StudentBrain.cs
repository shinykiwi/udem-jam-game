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
        BurntOut,
        Question,
        Null,
    }

    private bool canRoll = true;
    
    private EmoteController emoteController;
    public EmoteController Emote { get; set; }
    
    private StudentState state;
    public StudentState State
    {
        get { return state; }
        
        set
        {
            StudentState oldState = state;
            state = value;
            
            Debug.Log(studentData.studentName +"changing from " + oldState + " to " + state);
            
            if (oldState != state)
            {
                UpdateState(oldState);
            }
        }
    }
    
    [SerializeField] private StudentData studentData;

    private void Start()
    {
        StartCoroutine(RollDiceContinuously());
    }

    public void UpdateState(StudentState oldState = StudentState.Null )
    {
        if (oldState != State)
        {
            switch (oldState)
            {
                case StudentState.Idle:
                    break;
                case StudentState.Learning:
                    GameManager.Instance.LearningStudents--;
                    break;
                case StudentState.Attentive:
                    GameManager.Instance.AttentiveStudents--;
                    break;
                case StudentState.BurntOut:
                    GameManager.Instance.BurnoutStudents--;
                    break;
                case StudentState.Question:
                    GameManager.Instance.FocusPoints++;
                    break;
            }
        }
        switch (State)
        {
            case StudentState.Idle:
                Emote.EmoteBored();
                break;
            case StudentState.Learning:
                Emote.EmoteLearning();
                GameManager.Instance.LearningStudents++;
                break;
            case StudentState.Attentive:
                Emote.EmoteHappy();
                GameManager.Instance.AttentiveStudents++;
                break;
            case StudentState.BurntOut:
                Emote.EmoteUnhappy();
                GameManager.Instance.BurnoutStudents++;
                break;
            case StudentState.Question:
                Emote.EmoteQuestion();
                break;
            case StudentState.Null:
                StartCoroutine(RollDiceContinuously());
                break;
        }
    }


    public void enterPreviousState()
    {
        State = previousState;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canRoll = !canRoll;
        }
    }

    IEnumerator RollDiceContinuously()
    {
        
        while (canRoll && (State != StudentState.Question))
        {
            yield return new WaitForSeconds(studentData.secondsBetweenRolls);
            switch (State)
            {
                case StudentState.Idle:
                    RollAttentiveDice(); 
                    break;
                case StudentState.Learning:
                    RollLearningDice();
                    break;
            }
            RollBurntOutDice();
            RollQuestionDice();

        }
        
    }

    
    StudentState previousState = StudentState.Null;
    private bool RollQuestionDice()
    {
        float questionRoll = 0.2f;
        
        float rand = Random.Range(0f, 1f);
        if (rand <= (questionRoll))
        {
            // If it passes, change the state to learning
            previousState = State;
            State = StudentState.Question;
            
            return true;
        }
        return false;
        
    }
    private void RollLearningDice()
    {
        
        // ex. 0.2 * 0.9 = 0.18
        float learningRoll = studentData.learningTendency * GameManager.Instance.Comprehension;

        // ex. check if a random float is less than or equal to 0.18, thus passing the check
        // like rolling a die
        
        float rand = Random.Range(0f, 1f);
        if (rand <= (learningRoll))
        {
            // If it passes, change the state to learning
            State = StudentState.Learning;
        }
    }
    private void RollAttentiveDice()
    {
        float attentiveRoll = studentData.attentiveTendency * GameManager.Instance.Engagement;

        // If the student is already attentive, they are more likely to stay attentive
        if (State == StudentState.Attentive)
        {
            attentiveRoll *= 2;
        }
        
        float rand = Random.Range(0f, 1f);
        
        if (rand <= attentiveRoll)
        {
            State = StudentState.Attentive;
        }
    }
    private void RollBurntOutDice()
    {
        float burnoutRoll = studentData.burnoutTendency * GameManager.Instance.Burnout;

        float rand = Random.Range(0f, 1f);
        if (rand <= burnoutRoll)
        {
            State = StudentState.BurntOut;
            //Debug.Log("Success!");
        }
        else
        {
            //Debug.Log("No luck!");
        }
        
        //Debug.Log(rand + "<= " + burnoutRoll);
    }
}
