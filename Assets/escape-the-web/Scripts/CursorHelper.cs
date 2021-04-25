using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHelper : MonoBehaviour
{
    public Texture2D cursorArrow;
    public Texture2D cursorHand;
    // Start is called before the first frame update
    void Start()
    {
        SetCursor();
    }

    void SetCursor()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
