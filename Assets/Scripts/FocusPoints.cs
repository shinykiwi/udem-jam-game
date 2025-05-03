using System;
using TMPro;
using UnityEngine;

public class FocusPoints : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;


    public void Start()
    {
        GameManager.Instance.OnFocusPointsChanged += SetFocusPoints;
    }

    public void SetFocusPoints(int val)
    {
        Debug.Log(val);
        textMeshPro.text = "Focus: " + val.ToString();
    }
}
