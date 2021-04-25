using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public LivesTracker tracker;
    private int health;
    private int maxHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = tracker.GetLives();
        hearts[hearts.Length-1].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        health = tracker.GetLives();
        for (int i = 0; i < hearts.Length-1; i++) {

            if (i < health) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}
