using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // https://www.youtube.com/watch?v=9HvTwtfBaYM
    public TMP_Text scoreText;
    public float scoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;
    static float score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
            score = scoreCount;
            // scoreText.text = "Score: " + Mathf.Round(scoreCount);
        }
    }

    public float GetScore() { return score; }
}
