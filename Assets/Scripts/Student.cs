using System;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class Student : MonoBehaviour
{
    private Outline outline;
    private EmoteController emoteController;
    
    public EmoteController Emote { get; private set; }

    private void Start()
    {
        if (!outline)
        {
           outline = gameObject.GetComponent<Outline>(); 
        }

        if (!outline)
        {
            outline = gameObject.AddComponent<Outline>();
            outline.OutlineWidth = 10;
        }
        
        outline.enabled = false;
        
        Emote = gameObject.GetComponentInChildren<EmoteController>();
        
        if (!Emote)
        {
            Debug.LogWarning("No emote controller found");
        }
    }

    public void HideOutline()
    {
        outline.enabled = false;
    }

    public void ShowOutline()
    {
        outline.enabled = true;
    }
}
