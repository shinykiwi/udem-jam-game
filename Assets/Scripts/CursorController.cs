using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D clickableCursor;
    void Start()
    {
        // Set the initial cursor
        SetDefaultCursor();
    }

    private void SetCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void SetDefaultCursor()
    {
        SetCursor(defaultCursor);
    }

    public void SetClickableCursor()
    {
        SetCursor(clickableCursor);
    }
    
}
