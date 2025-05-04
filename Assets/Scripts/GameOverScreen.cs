using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private Canvas canvas;
    public static GameOverScreen Instance { get; private set; }
    
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }

    private void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void Show()
    {
        canvas.enabled = true;
    }
}
