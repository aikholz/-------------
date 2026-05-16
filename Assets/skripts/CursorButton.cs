using UnityEngine;
using UnityEngine.EventSystems;

public class CursorButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CursorManager cursorManager;
    private Vector3 originalScale;

    [SerializeField] private float hoverScale = 1.2f;
    [SerializeField] private bool isSettingsButton = false;

    void Start()
    {
        cursorManager = FindObjectOfType<CursorManager>();
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (cursorManager != null)
            cursorManager.SetButtonCursor();

        if (isSettingsButton)
            transform.localScale = originalScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (cursorManager != null)
            cursorManager.SetDefaultCursor();

        if (isSettingsButton)
            transform.localScale = originalScale;
    }
}