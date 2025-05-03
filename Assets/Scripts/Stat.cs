using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI statText;
    [SerializeField] Slider statSlider;
    
    public void SetStat(float stat)
    {
        statSlider.value = stat;
    }
}
