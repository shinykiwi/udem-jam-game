using System;
using TMPro;
using UnityEngine;

public class FocusPoints : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] PointVariable focusPoints;

    public void Start()
    {
        focusPoints.OnValueChange += SetFocusPoints;
    }

    public void SetFocusPoints()
    {
        
        textMeshPro.text = "Focus: " + focusPoints.Value.ToString();
    }
}
