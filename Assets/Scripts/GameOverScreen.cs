using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private Canvas canvas;
    public static GameOverScreen Instance { get; private set; }

    [SerializeField] private PlayerRaycast playerRaycast;
    [SerializeField] private GameObject upgradesPage;
    [SerializeField] private GameObject upgradesButton;
    bool playedSound = false;
    
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
        if (!playedSound)
        {
            SoundManager.PlaySound(SoundManager.SoundType.BELL);
            playedSound = true;
        }
        canvas.enabled = true;
        playerRaycast.enabled = false;
        upgradesButton.SetActive(false);
        upgradesPage.SetActive(false);
        Time.timeScale = 0f;

    }
}
