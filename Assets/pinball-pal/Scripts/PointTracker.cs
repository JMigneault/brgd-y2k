using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTracker : MonoBehaviour
{
    public LivesTracker livesTracker;

    private int points;
    private int cumulativePoints = 0;

    public int bonusRoundThreshold;
    public bool isBonusRoundAwarded = false;

    void Start() {
        PlayerPrefs.SetInt("r1Score", 0);
        PlayerPrefs.SetInt("r2Score", 0);
        PlayerPrefs.SetInt("r3Score", 0);
        PlayerPrefs.SetInt("r4Score", 0);

    }

    public void ResetPoints(int round) {
        Debug.Log("Set var: " + "r" + round + "Score" + " to score: " + points);
        PlayerPrefs.SetInt("r" + round + "Score", points);
        points = 0;
    }

    public void AddPoints(int newPoints) {
        this.points += newPoints;
        this.cumulativePoints += newPoints;
        if (cumulativePoints/3 >= bonusRoundThreshold && !isBonusRoundAwarded)
        {
            print("bonus round awarded!");
            isBonusRoundAwarded = true;
        }
    }

    public int GetPoints() {
        return points;
    }

    public int GetCumulativePoints() {
        return cumulativePoints;
    }

}

