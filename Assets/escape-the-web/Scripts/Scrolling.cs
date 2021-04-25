using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public bool exitable = false;

    //adding difficutly?
    void Start()
    {
         
    }       

    // Update is called once per frame
    void Update()
    {
        this.rb.velocity = new Vector2(0.0f, -0.25f);
    }
}
