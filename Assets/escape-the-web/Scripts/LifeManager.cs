using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    // Start is called before the first frame update
    //https://forum.unity.com/threads/lives-script.503203/
    public int lives;
    public Rigidbody2D player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            // Debug.Log("GAME OVER!");
            SceneManager.LoadScene("etwGameOver");
        }
        else if (this.player.position.y > 12.0f ||  // originally 7.8f; "grace period" distance for respawn
                this.player.position.y < -6.5f ||
                this.player.position.x > 12.5f ||
                this.player.position.x < -12.5f)
        {
            lives--;
            this.player.transform.position = new Vector2(0, 5);
            this.player.velocity = new Vector2(0, 0);
            Debug.Log(lives);
        }
    }
    // void OnCollisionEnter2D(Collision2D coll)
    // {
    //     string tag = coll.collider.gameObject.tag;
    //     if (tag == "Glitch"){
    //         lives--;
    //         this.player.transform.position = new Vector2(0, 5);
    //         Debug.Log("LIVES DECREASED FROM GLITCH COLLISION");
    //         Debug.Log(lives);
    //     }
    // }
}
