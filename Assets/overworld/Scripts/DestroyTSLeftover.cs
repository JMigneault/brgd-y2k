using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTSLeftover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // delete DontDeleteOnLoad objects from TS
        GameObject ch = GameObject.Find("Cursor Handler");
        GameObject tm = GameObject.Find("TitleMusic");
        GameObject dh = GameObject.Find("Difficulty Handler");
        GameObject.Destroy(ch);
        GameObject.Destroy(tm);
        GameObject.Destroy(dh);

        // reset cursor from etw
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
