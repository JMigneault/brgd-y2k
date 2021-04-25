using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D scrollBar;
    public bool exitable;
    public Rigidbody2D exitButton;
    public Rigidbody2D player;
    public bool spawned;
    public float difficultyFactor;
    public float scrollStartX;
    public Texture2D cursorArrow;
    public Texture2D cursorHand;

    public AudioSource loopingSound;
    private GameObject statsDisplay;
    private StatsDisplay stats;

    void Start()
    {
        spawned = false;
        // this.exitButton.transform.position = new Vector3(-10, -10, 10); //change to z later
        difficultyFactor = 1;
        scrollStartX = this.scrollBar.position.x;
        statsDisplay = GameObject.Find("StatsDisplay");
        stats = statsDisplay.GetComponent<StatsDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.scrollBar.position.y > 1.8f){
            spawned = false;
        }
        if(this.scrollBar.position.y < -2.75f && spawned == false){
            spawned = true;
            this.exitButton.transform.position = new Vector2(0, -2.5f);
        }
    }
    void OnMouseDown() //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single)
    {
        this.exitButton.transform.position = new Vector2(-10, -10);
        this.scrollBar.transform.position = new Vector3(scrollStartX, 3.65f, -1);
        this.player.transform.position = new Vector2(0, 3);
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        GameObject go = GameObject.Find("Score");
        ScoreManager score = go.GetComponent<ScoreManager>();
        score.scoreCount = score.scoreCount + 100;
        stats.incrementFirewallCount(1);

        difficultyFactor++;
        Debug.Log(difficultyFactor);

        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.loopingSound.Play();
        enemySpawner.GetComponent<SpawnEnemies>().enemySpawnProb /= 3;
    }
    void OnMouseEnter(){
        Cursor.SetCursor(cursorHand, Vector2.zero, CursorMode.ForceSoftware);
    }
    void OnMouseExit(){
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
