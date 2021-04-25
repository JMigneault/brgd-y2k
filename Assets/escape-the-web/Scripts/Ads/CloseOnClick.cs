using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOnClick : MonoBehaviour
{
    public GameObject toDestroy;

    void OnMouseDown()
    {
        Destroy(toDestroy);
    }
}
