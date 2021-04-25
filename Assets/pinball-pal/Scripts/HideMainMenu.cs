using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMainMenu : MonoBehaviour
{

    public Canvas can;

    // Start is called before the first frame update
    public void hideCanvas()
    {
        can.enabled = false;
    }


    public bool returnCanvasState() {
        return (can.enabled);
    }

}
