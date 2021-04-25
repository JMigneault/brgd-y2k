using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;


    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
     if (timerIsRunning) {
         if (timeRemaining > 0){
             timeRemaining -= Time.deltaTime;
             DisplayTime(timeRemaining);
         } else{
             Debug.Log("time has run out!");
             timeRemaining = 0;
             timerIsRunning = false;
         }
     }
    }

    void DisplayTime(float timeToDisplay){
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
