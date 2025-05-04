using System;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public static LanguageButton instance;

    public void Awake()
    {
        instance = this;
        botton = gameObject.GetComponent<Button>();
        
        
    }


    private Button botton;
}
