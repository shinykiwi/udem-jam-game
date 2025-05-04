using UnityEngine;

[CreateAssetMenu(fileName = "StudentData", menuName = "ScriptableObjects/StudentData", order = 1)]
public class StudentData : ScriptableObject
{
    public string studentName;
    
    [Range(0.001f, 1f)]
    public float attentiveTendency = 0.5f;
    
    [Range(0.001f, 1f)]
    public float learningTendency = 0.5f;
    
    [Range(0.001f, 1f)]
    public float burnoutTendency = 0.5f;


    [Range(0.001f, 1f)]
    public float attentiveThreshold = 0.5f;
    
    [Range(0.001f, 1f)]
    public float learningThreshold = 0.5f;
    
    [Range(0.001f, 1f)]
    public float burnoutThreshold = 0.5f;

    
    
    
    [Range(1f, 15f)]
    public float secondsBetweenRolls = 5f;
    
    
    
}