using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Cursor Sprites")]
    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D buttonCursor;
    [SerializeField] private Vector2 hotspot = Vector2.zero;

    void Start()
    {
        SetDefaultCursor();
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    public void SetButtonCursor()
    {
        Cursor.SetCursor(buttonCursor, hotspot, CursorMode.Auto);
    }
}