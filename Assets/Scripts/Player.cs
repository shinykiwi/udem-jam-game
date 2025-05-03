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
        if (!playerRaycast.LastStudent) return;
        
        // --- Clicking on a student ---
        
        // Play a sound
        SoundManager.PlaySound(SoundManager.SoundType.SELECT);
        
        
        EmoteController emote = playerRaycast.LastStudent.Emote;

        StudentBrain studentBrain = playerRaycast.LastStudent.Brain;
        
        
        emote.StopEmoting();

        

    }
}
