using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGlitchMvmt : MonoBehaviour
{
    // Start is called before the first frame update
    public bool right;
    public Rigidbody2D shadowGlitch;
    public Sprite rightFace;
    public Sprite leftFace;

    void Start()
    {
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shadowGlitch.position.x > 10){
            right = false;
        } 
        if (shadowGlitch.position.x < -10){
            right = true;
        }
        if (right){
            this.moveRight();
        } else{
            this.moveLeft();
        }
    }
    
    void moveRight(){
        this.shadowGlitch.gameObject.GetComponent<SpriteRenderer>().sprite = rightFace;
        this.shadowGlitch.velocity = new Vector2(2.5f, 0);
    }
    void moveLeft(){
        this.shadowGlitch.gameObject.GetComponent<SpriteRenderer>().sprite = leftFace;
        this.shadowGlitch.velocity = new Vector2(-2.5f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider){ //subtract user lives
        Debug.Log("collided");
    }
}
