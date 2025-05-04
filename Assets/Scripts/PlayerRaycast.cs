using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public Student LastStudent { get; private set; }

    private CursorController cursorController;

    bool playedSound = false;

    private void Start()
    {
        cursorController = GetComponentInChildren<CursorController>();
    }

    private void Dehover()
    {
        LastStudent?.HideOutline();
        LastStudent = null;
        cursorController.SetDefaultCursor();
        playedSound = false;
    }

    void Update()
    {
        // Sending a raycast from the mouse position (which is already locked to middle of screen)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
        // If something was hit
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.GetComponent<Student>() is { } student)
            {

                if (LastStudent)
                {
                    if (LastStudent != student)
                    {
                        LastStudent.HideOutline();
                    }
                    
                }
                
                LastStudent = student;
                LastStudent.ShowOutline();
                cursorController.SetClickableCursor();
                
                if (!playedSound)
                {
                    SoundManager.PlaySound(SoundManager.SoundType.CURSOR);
                    playedSound = true;
                }
            }

            else
            {
                Dehover();
            }
        }
        else
        {
            Dehover();
        }
    }
}
