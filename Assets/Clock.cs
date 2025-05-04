using System;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private float minutes = 0;
    private int hours = 9;
    
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        minutes += Time.deltaTime;

        if (hours >= 13)
        {
            // end the day
            GameOverScreen.Instance.Show();
        }

        if (minutes > 59)
        {
            minutes = 0;
            hours++;
        }

        string end = hours < 12 ? "AM" : "PM";
        timeText.text = hours + ":" +minutes.ToString("00") + end;

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SpeedUp();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SpeedNormal();
        }
        
    }

    private void SpeedUp()
    {
        Time.timeScale *= 6;
    }

    private void SpeedNormal()
    {
        Time.timeScale = 1;
    }
}
