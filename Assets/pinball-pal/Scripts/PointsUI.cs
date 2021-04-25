using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{
    public PointTracker point_tracker;
    // Start is called before the first frame update
    public Text points_text;
    private int points;
    void Start()
    {
        // points_text.text = "Points: ";
        points_text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        points = point_tracker.GetPoints();
        points_text.text = "Points: " + points;
    }
}
