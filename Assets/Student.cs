using System;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class Student : MonoBehaviour
{
    private Outline outline;

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
    }

    public void HideOutline()
    {
        outline.enabled = false;
    }

    public void ShowOutline()
    {
        outline.enabled = true;
    }

    public void Learning()
    {
        
    }
}
