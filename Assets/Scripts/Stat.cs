using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI statText;
    [SerializeField] Slider statSlider;

    [SerializeField] StatVariable stat;
    
    public void Start()
    {
        stat.OnValueChange += SetStat;
        SetStat();
    }

    public void SetStat()
    {
        statSlider.value = stat.Value;
    }
}
