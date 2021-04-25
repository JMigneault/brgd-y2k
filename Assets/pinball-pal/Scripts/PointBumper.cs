using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBumper : MonoBehaviour
{

    AudioSource audioSource;
    SpriteRenderer sprite;
    Animator spriteAnimator;

    public PointTracker tracker;
    public int pointValue;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sprite = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteAnimator = sprite.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.transform.tag == "Pinball") {
            tracker.AddPoints(pointValue);
            audioSource.Play();
            spriteAnimator.SetBool("isHit", true);
            Invoke("StopShake", 0.2f);
            
        }
    }

    void StopShake()
    {
        spriteAnimator.SetBool("isHit", false);
    }

}
