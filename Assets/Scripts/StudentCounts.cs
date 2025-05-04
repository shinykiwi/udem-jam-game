using System;
using TMPro;
using UnityEngine;

public class StudentCounts : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI burnoutStudents;
    [SerializeField] private TextMeshProUGUI learningStudents;
    [SerializeField] private TextMeshProUGUI attentiveStudents;

    public void Start()
    {
        GameManager.Instance.OnBurnedOutStudentsChanged += SetBurnout;
        GameManager.Instance.OnAttentiveStudentsChanged += SetAttentive;
        GameManager.Instance.OnLearningStudentsChanged += SetLearning;
    }

    //todo: Zaid fix this - Zaid
    /*
    private void OnEnable()
    {
        GameManager.Instance.OnBurnedOutStudentsChanged += SetBurnout;
        GameManager.Instance.OnAttentiveStudentsChanged += SetAttentive;
        GameManager.Instance.OnLearningStudentsChanged += SetLearning;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnBurnedOutStudentsChanged -= SetBurnout;
        GameManager.Instance.OnAttentiveStudentsChanged -= SetAttentive;
        GameManager.Instance.OnLearningStudentsChanged -= SetLearning;
    }
    */

    private void SetBurnout(float value)
    {
        burnoutStudents.text = value + " Burned out";
    }

    private void SetAttentive(float value)
    {
        attentiveStudents.text = value + " Paying attention";
    }

    private void SetLearning(float value)
    {
        learningStudents.text = value + " Learning";
    }
}
