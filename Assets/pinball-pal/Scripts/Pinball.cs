using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{

    AudioSource audioSource;
    public Vector2 startingPosition;
    Rigidbody2D rbd;
    SpriteRenderer spriteRenderer;

    public Sprite breakfast;
    public Sprite lunch;
    public Sprite dinner;
    public Sprite dessert;

    public int round = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = this.transform.position;
        rbd = this.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        this.transform.position = startingPosition;
        rbd.velocity = Vector3.zero;
        rbd.angularVelocity = 0f;
    }

    public void Reset() {
        Debug.Log("Called into Pinball");
        this.transform.position = startingPosition;
        round++;

        if(round == 1)
        {
            spriteRenderer.sprite = breakfast;
        }
        else if(round == 2)
        {
            spriteRenderer.sprite = lunch;
        }
        else if(round == 3)
        {
            spriteRenderer.sprite = dinner;
        }
        else
        {
            spriteRenderer.sprite = dessert;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag != "Bumper" && col.transform.tag != "Launcher")
        {
            audioSource.Play();
        }
    }
}
