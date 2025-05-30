using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "StatVariable", menuName = "Scriptable Objects/Create new stat")]
public class StatVariable : ScriptableObject
{
    [SerializeField] private float _value;
    public Action OnValueChange;


    public float Value
    {
        get => _value;
        set
        {
            _value = Mathf.Max(0, value);
            OnValueChange?.Invoke();
        }
    }
}
