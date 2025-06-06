using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI statText;
    [SerializeField] Slider statSlider;
    [SerializeField] MyEnum state;
    
    public enum MyEnum
    {
        Engagement, Comprehension, Burnout
    }

    public void Start()
    {
        switch (state)
        {
            case MyEnum.Engagement:
                GameManager.Instance.OnEngagementChanged += SetStat;
                break;
            case MyEnum.Comprehension:
                GameManager.Instance.OnComprehensionChanged += SetStat;
                break; 
            case MyEnum.Burnout:
                GameManager.Instance.OnBurnoutChanged += SetStat;
                break;
        }
    }

    public void SetStat(float stat)
    {
        statSlider.value = stat;
    }
}
