using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRegion : MonoBehaviour
{

    public LivesTracker liveTracker;
    public MoodDisplay moodDisplay;
    public PointTracker pointTracker;
    public Transform ballExit;

    public AudioSource crunchSource;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Hit death region");
        if (ballExit == null)
        {
            liveTracker.LoseLife();
            if (liveTracker.GetLives() > 0)
            {
                collider.GetComponent<Pinball>().Reset();
                collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                collider.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            }
            else
            {
                collider.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                //END GAME, CALCULATE SCORE
            }

        }
        else
        {
            moodDisplay.ShowMood(pointTracker.GetPoints());
            collider.GetComponent<Pinball>().transform.position = ballExit.position;
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            collider.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;

            Invoke("playCrunch", 0.2f);
        }

    }

    void playCrunch()
    {
        crunchSource.Play();
    }

}
