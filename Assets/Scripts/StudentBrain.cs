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
            
            if (oldState != state)
            {
                UpdateState();
            }
        }
    }
    
    [SerializeField] private StudentData studentData;

    private void Start()
    {
        Debug.Log("Seconds between rolls for " + name + ": " + studentData.secondsBetweenRolls);
        Debug.Log("Learning tendency " + studentData.learningTendency);
        Debug.Log("Attentive tendency " + studentData.attentiveTendency);
        Debug.Log("Burnout tendency " + studentData.burnoutTendency);

        GameManager.Instance.Comprehension = 0.9f;
        GameManager.Instance.Engagement = 0.6f;
        GameManager.Instance.Burnout = 0.2f;
        
        Debug.Log("GameManager Comprehension " + GameManager.Instance.Comprehension);
        Debug.Log("GameManager Engagement " + GameManager.Instance.Engagement);
        Debug.Log("GameManager Burntout " + GameManager.Instance.Burnout);
        
        StartCoroutine(RollDiceContinuously());
    }

    public void UpdateState()
    {
        switch (State)
        {
            case StudentState.Idle:
                Emote.EmoteBored();
                break;
            case StudentState.Learning:
                Emote.EmoteLearning();
                break;
            case StudentState.Attentive:
                Emote.EmoteHappy();
                break;
            case StudentState.BurntOut:
                Emote.EmoteUnhappy();
                break;
            case StudentState.Question:
                Emote.EmoteQuestion();
                break;
            case StudentState.Null:
                StartCoroutine(RollDiceContinuously());
                break;
        }
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
        Debug.Log("Dice rolling started.");
        
        while (canRoll && (State != StudentState.Question))
        {
            yield return new WaitForSeconds(studentData.secondsBetweenRolls);
            
            RollLearningDice();
            RollAttentiveDice();
            RollBurntOutDice();
            
        }
        
        Debug.Log("Dice rolling stopped.");
    }

    private bool RollQuestionDice()
    {
        float questionRoll = 0.5f;
        
        float rand = Random.Range(0f, 1f);
        if (rand <= (questionRoll))
        {
            // If it passes, change the state to learning
            State = StudentState.Question;
            //Debug.Log("Success!");
            return true;
        }
        else
        {
            //Debug.Log("No luck!");
            return false;
        }
        
    }
    private void RollLearningDice()
    {
        if (RollQuestionDice())
        {
            return;
        }
        
        // ex. 0.2 * 0.9 = 0.18
        float learningRoll = studentData.learningTendency * GameManager.Instance.Comprehension;

        // ex. check if a random float is less than or equal to 0.18, thus passing the check
        // like rolling a die
        
        float rand = Random.Range(0f, 1f);
        if (rand <= (learningRoll))
        {
            // If it passes, change the state to learning
            State = StudentState.Learning;
            //Debug.Log("Success!");
        }
        else
        {
            //Debug.Log("No luck!");
        }
        
        //Debug.Log(rand + "<= " + learningRoll);
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
            //Debug.Log("Success!");
        }
        else
        {
            //Debug.Log("No luck!");
        }
        
        //Debug.Log(rand + "<= " + attentiveRoll);
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
