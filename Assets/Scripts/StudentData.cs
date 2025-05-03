using UnityEngine;

[CreateAssetMenu(fileName = "StudentData", menuName = "ScriptableObjects/StudentData", order = 1)]
public class StudentData : ScriptableObject
{
    [Range(0.001f, 1f)]
    [SerializeField] private float attentiveTendency = 0.5f;
    
    [Range(0.001f, 1f)]
    [SerializeField] private float learningTendency = 0.5f;
    
    [Range(0.001f, 1f)]
    [SerializeField] private float burnoutTendency = 0.5f;
}

