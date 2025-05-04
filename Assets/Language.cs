using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public static bool isEnglish = true;

    
    public static Language instance;


    public Button button;
    public void Awake()
    {
        instance = this;
        button = GetComponent<Button>();
    }
    
    
    public void changeLanguage()
    {
        isEnglish = !isEnglish;
    }
}
