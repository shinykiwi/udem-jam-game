using System;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    
    [SerializeField] string english_text;
    [SerializeField] string french_text;

    
    TextMeshProUGUI textMesh;
    public void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text =  Language.isEnglish? english_text : french_text;
    }
}
