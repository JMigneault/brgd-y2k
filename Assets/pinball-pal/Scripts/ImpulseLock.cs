using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseLock : MonoBehaviour
{

    private bool isBouncing;
    private Vector3 direction;
    private Rigidbody2D rigid;
    private float impulseForce = 800;


    void OnCollisionEnter2D(Collision2D collidedObject)
    {
        if (collidedObject.gameObject.tag == "Pinball")
        {
            rigid = collidedObject.gameObject.GetComponent<Rigidbody2D>();

            direction = rigid.velocity.normalized;
            rigid.velocity = Vector3.zero;
            rigid.AddForce(direction * impulseForce);
            isBouncing = true;
            Invoke("StopBounce", 0.3f);
        }
    }

    void StopBounce()
    {
        isBouncing = false;
    }

}
