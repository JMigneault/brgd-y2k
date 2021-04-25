using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Springer : MonoBehaviour
{
    AudioSource audioSource;

    public float launchForce;
    public float launchAdditive = 0f;
    private float launchAdditiveMax = 3f;
    public float downTime, pressTime = 0;

    public GameObject pinball;
    private Rigidbody2D pinballBody;
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        pinballBody = pinball.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {   
            if (triggered == true)
            {
                pinballBody.AddForce(Vector3.up * (launchForce + launchAdditive), ForceMode2D.Impulse);
                audioSource.Play();
                triggered = false;
            }

            else
            {
                launchAdditive = 0f;
            }
        }

        if (Input.GetKey("space") && launchAdditive <= launchAdditiveMax)
        {
            launchAdditive = launchAdditive + 0.01f;
        }
       
    }

    void OnTriggerStay2D(Collider2D collidedObject)
    {
        if (collidedObject.gameObject.tag == "Pinball" && !triggered) {
            print("ball registered!");
            triggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D collidedObject)
    {
        triggered = false;
        
    }

}
