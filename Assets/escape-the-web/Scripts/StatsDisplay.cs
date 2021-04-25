
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatsDisplay : MonoBehaviour
{
    // public GameObject lifeIconPrefab;
    // public GameObject firewallIconPrefab;
    private GameObject Player;
    private GameObject Score;
    private GUIStyle guiStyle = new GUIStyle();
    private GUIStyle scoreStyle = new GUIStyle();
    private int firewallCount = 0;

    public float DesignWidth = 1920.0f;
    public float DesignHeight = 1080.0f;
    public Texture lifeIconTexture;
    public Texture firewallIconTexture;
    public Font font;

    // Start is called before the first frame update
    void Start()
    {
        // Gui style 
        guiStyle.fontSize = 50; //change the font size
        guiStyle.normal.textColor = Color.white; //change the font color
        guiStyle.alignment = TextAnchor.UpperCenter;
        guiStyle.font = font;

        scoreStyle.fontSize = 80; //change the font size
        scoreStyle.normal.textColor = Color.white; //change the font color
        scoreStyle.alignment = TextAnchor.UpperLeft;
        scoreStyle.font = font;
        Player = GameObject.Find("Player");
        Score = GameObject.Find("Score");

        // GameObject lifeIcon = (GameObject) Instantiate(lifeIconPrefab, new Vector2(100, 45), Quaternion.identity);
        // lifeIcon.transform.SetParent(this.transform);
    }

    void OnGUI()
    {
        float resX = (float) (Screen.width) / DesignWidth;
        float resY = (float) (Screen.height) / DesignHeight;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(resX, resY, 1));

        string lifeText = "x" + Player.GetComponent<LifeManager>().lives;
        string firewallText = "x" + firewallCount;
        string scoreText = "SCORE: " + Mathf.Round(Score.GetComponent<ScoreManager>().GetScore());

        int xPos = 180;
        int imageYPos = 100;
        int textYPos = imageYPos + 20;
        int iconTextGap = 80;

        GUI.Label(new Rect(xPos, 20, 10, 40), scoreText, scoreStyle);

        GUI.DrawTexture(new Rect(xPos, imageYPos, 80, 80), lifeIconTexture, ScaleMode.ScaleToFit, true);
        GUI.Label(new Rect(xPos + iconTextGap, textYPos, 100, 40), lifeText, guiStyle);

        xPos += 260;
        GUI.DrawTexture(new Rect(xPos, imageYPos, 80, 80), firewallIconTexture, ScaleMode.ScaleToFit, true);
        GUI.Label(new Rect(xPos + iconTextGap, textYPos, 100, 40), firewallText, guiStyle);
    }

    public void incrementFirewallCount(int incValue) {
        this.firewallCount += incValue;
    }
}


