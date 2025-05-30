using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PointVariable", menuName = "Scriptable Objects/PointVariable")]
public class PointVariable : ScriptableObject
{
    [SerializeField] private int _value;
    public Action OnValueChange;

    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            OnValueChange?.Invoke();
        }
    }

    private void OnDisable()
    {
        if (Application.isPlaying)
        {
            _value = 0;
        }
    }

}
