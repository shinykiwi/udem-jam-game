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
            
            Debug.Log(studentData.studentName +" changing from " + oldState + " to " + state);
            
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


    public static bool isPaused;
    IEnumerator RollDiceContinuously()
    {

        
        
        while (canRoll)
        {
            
            while (isPaused)
            {
                yield return null;
            }

            //Debug.Log(studentData.studentName + " is rolling");
            yield return new WaitForSeconds(studentData.secondsBetweenRolls);
            
            //Just dont roll if still asking
            if (State == StudentState.Question)  continue;
            
            //If you become attentive, dont immediately change to another state
            bool transitioned = false;
            switch (State)
            {
                case StudentState.Idle:
                    transitioned = RollAttentiveDice(); 
                    break;
                case StudentState.Attentive:
                    transitioned = RollLearningDice();
                    break;
            }
            
            if (transitioned)
                continue;
            
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
            previousState = state;
            State = StudentState.Question;
            
            return true;
        }
        return false;
        
    }
    private bool RollLearningDice()
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
            return true;
        }
        return  false;
    }
    private bool RollAttentiveDice()
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
            return true;
        }
        return false;
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
