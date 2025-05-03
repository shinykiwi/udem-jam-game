using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Student lastStudent;
    private CursorController cursorController;

    private void Start()
    {
        cursorController = GetComponentInChildren<CursorController>();
    }

    private void Dehover()
    {
        lastStudent?.HideOutline();
        lastStudent = null;
        cursorController.SetDefaultCursor();
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
                lastStudent = student;
                lastStudent.ShowOutline();
                cursorController.SetClickableCursor();
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
