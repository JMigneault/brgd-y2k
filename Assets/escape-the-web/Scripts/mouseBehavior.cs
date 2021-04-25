using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursorHand;
    public Texture2D cursorArrow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter(){
        Cursor.SetCursor(cursorHand, Vector2.zero, CursorMode.ForceSoftware);
    }
    void OnMouseExit(){
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
