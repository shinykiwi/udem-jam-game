using System;
using TMPro;
using UnityEngine;

public class StudentCounts : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI burnoutStudents;
    [SerializeField] private TextMeshProUGUI learningStudents;
    [SerializeField] private TextMeshProUGUI attentiveStudents;


    private string englishBurnout = "Burntout";
    private string englishLearning = "Learning";
    private string englishAttentive = "Attentive";
    private string frenchBurnout = "Fatigués";
    private string frenchLearning = "Apprentissage";
    private string frenchAttentive = "Attentifs";
    
    //todo: Zaid fix this - Zaid
    private static int _learningCount = 0;
    private static int _attentiveCount = 0;
    private static int _burnoutCount = 0;


    
    
    public static int BurnoutCount
    {
        get => _burnoutCount;
        set
        {
            _burnoutCount = value;
            instance.SetBurnout();
        }
    }
    public static int AttentiveCount
    {
        get => _attentiveCount;
        set
        {
            _attentiveCount = value;
            instance.SetAttentive();
        }
    }
    public static int LearningCount
    {
        get => _learningCount;
        set
        {
            _learningCount = value;
            instance.SetLearning();
        }
    }
    
    
    public static StudentCounts instance;

    private void Awake()
    {
        instance = this;
        SetBurnout();
        SetLearning();
        SetAttentive();
    }
    

    private void SetBurnout()
    {
        
        
        burnoutStudents.text = _burnoutCount + " " + (Language.isEnglish ? englishBurnout : frenchBurnout);
    }

    private void SetAttentive()
    {
        attentiveStudents.text = _attentiveCount + " " + (Language.isEnglish ? englishAttentive : frenchAttentive);
    }

    private void SetLearning()
    {
        
        learningStudents.text = _learningCount + " " + (Language.isEnglish ? englishLearning : frenchLearning);
    }


    
}
