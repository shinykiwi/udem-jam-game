using System;
using TMPro;
using UnityEngine;

public class SwapText : MonoBehaviour
{
    public string englishText;
    public string frenchText;


    public void Start()
    {
        Language.instance.button.onClick.AddListener(replaceText);
    }

    TextMeshProUGUI textMesh;
    public void replaceText()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
        if (Language.isEnglish)
        {
            textMesh.text = englishText;
        }
        else
        {
            textMesh.text = frenchText;
        }
    }
}
