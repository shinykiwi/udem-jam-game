using System;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class Student : MonoBehaviour
{
    private Outline outline;
    private EmoteController emoteController;
    private StudentBrain studentBrain;
    
    public StudentBrain Brain { get; private set; }

    public StudentBrain.StudentState getState()
    {
        return Brain.State;
    }

    public EmoteController Emote
    {
        get
        {
            return emoteController;
        }
        
        private set
        {
            emoteController = value;
            Brain.Emote = emoteController;
        }
    }
    
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

        Brain = GetComponentInChildren<StudentBrain>();
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
