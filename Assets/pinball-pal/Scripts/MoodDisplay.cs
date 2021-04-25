using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodDisplay : MonoBehaviour
{
    public PointTracker tracker;
    public Animator animator;
    public Text mood_text;
    public GameObject pet;

    public int mehThreshold = 15;
    public int psychedThreshold = 30;

    public Sprite psyched;
    public Sprite meh;
    public Sprite bummed;
    public Sprite happy;

    public AudioSource psychedSource;
    public AudioSource mehSource;
    public AudioSource bummedSource;

    // Start is called before the first frame update
    void Start()
    {
        mood_text = GetComponent<Text>();
        mood_text.gameObject.SetActive(false);
    }

    public void ShowMood(int points) {
        // display mood
        mood_text.gameObject.SetActive(true);
        StartCoroutine(DisplayMessage(points));
    }

    IEnumerator DisplayMessage (int points) {
        // set mood
        if (points < mehThreshold) {
            //mood_text.text = "Mood: Bummed";
            animator.SetTrigger("roundEnd");
            animator.SetInteger("mood", 0);
            pet.GetComponent<SpriteRenderer>().sprite = bummed;
            Invoke("playBummed", 1f);
        }
        else if (points < psychedThreshold) {
            //mood_text.text = "Mood: Meh";
            animator.SetTrigger("roundEnd");
            animator.SetInteger("mood", 1);
            pet.GetComponent<SpriteRenderer>().sprite = meh;
            Invoke("playMeh", 1f);
        }
        else {
           // mood_text.text = "Mood: Psyched";
            animator.SetTrigger("roundEnd");
            animator.SetInteger("mood", 2);
            pet.GetComponent<SpriteRenderer>().sprite = psyched;
            Invoke("playPsyched", 1f);
        }

        // display mood
        yield return new WaitForSeconds(3);
        mood_text.gameObject.SetActive(false);
    }

    void playPsyched()
    {
        psychedSource.Play();
    }

    void playMeh()
    {
        mehSource.Play();
    }

    void playBummed()
    {
        bummedSource.Play();
    }
}
