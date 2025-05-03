using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerRaycast playerRaycast;

    private void Start()
    {
        playerRaycast = GetComponentInChildren<PlayerRaycast>();
    }

    public void OnClickObject()
    {
        // Clicks on a student
        if (playerRaycast.LastStudent)
        {
            EmoteController emote = playerRaycast.LastStudent.Emote;
            
            emote.StopEmoting();
            
        }
        
    }
}
