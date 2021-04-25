using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Typerspace;

public class PlayerPrefLeaderboardCreate : MonoBehaviour
{
    void Start()
    {
        int tenthScore = PlayerPrefs.GetInt("leaderboard[9].score", 0);
        if (tenthScore == 0)
        {
            Typerspace.Leaderboard.Record("Barbie", 1000);
            Typerspace.Leaderboard.Record("Britney", 900);
            Typerspace.Leaderboard.Record("Clippy", 800);
            Typerspace.Leaderboard.Record("Doctor", 700);
            Typerspace.Leaderboard.Record("Dramagotchi", 600);
            Typerspace.Leaderboard.Record("Psychiatrist", 500);
            Typerspace.Leaderboard.Record("Ratz", 400);
            Typerspace.Leaderboard.Record("Slinky", 300);
            Typerspace.Leaderboard.Record("Snerf", 200);
            Typerspace.Leaderboard.Record("Clicky", 100);
        }
    }
}
