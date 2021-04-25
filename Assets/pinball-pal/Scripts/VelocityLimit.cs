using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimit : MonoBehaviour
{

    public float velocityLimit = 10f;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude > velocityLimit)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, velocityLimit);
        }
    }
 
    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 200, 200), "rigidbody velocity: " + GetComponent<Rigidbody2D>().velocity);
    }
}