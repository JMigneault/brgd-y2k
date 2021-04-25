using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallResetter : MonoBehaviour
{
    private void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Pinball")
        {
            print("Resetting ball in tube!");
            collider.GetComponent<Pinball>().transform.position = collider.GetComponent<Pinball>().startingPosition;
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            collider.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }

    }
}
