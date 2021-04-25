using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSequencer : MonoBehaviour
{

    public GameObject pointUiParent;

    // these should match the thresholds for the main scene mood ui
    public int mehThreshold;
    public int psychedThreshold;

    public AudioClip bummedClip;
    public AudioClip mehClip;
    public AudioClip psychedClip;
    public AudioClip musicLoop;

    private AudioSource source;
    public AudioSource music;
    

    public float displayWait = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(DoSequence());
    }

    void Update() {
        if (!music.isPlaying) {
            Debug.Log("music stopped!");
            music.clip = musicLoop;
            music.loop = true;
            music.Play();
        }

    }

    /*
     * This script is kind of awful but allows easy modification of the final score sequence...
     * 
     */
    IEnumerator DoSequence() {
        int r1Score = PlayerPrefs.GetInt("r1Score");
        int r2Score = PlayerPrefs.GetInt("r2Score");
        int r3Score = PlayerPrefs.GetInt("r3Score");
        int r4Score = PlayerPrefs.GetInt("r4Score");

        int totalScore = r1Score + r2Score + r3Score + r4Score;
        float moodScore = totalScore / 3.0f;
        string moodStringC;

        if (moodScore < mehThreshold) {
            moodStringC = "Bummed";
            source.clip = bummedClip;
        }
        else if (moodScore < psychedThreshold) {
            moodStringC = "Meh";
            source.clip = mehClip;
        }
        else {
            moodStringC = "Psyched";
            source.clip = psychedClip;
        }

        string r1String = r1Score.ToString();
        string r2String = r2Score.ToString();
        string r3String = r3Score.ToString();
        string r4String = r4Score > 0 ? r4Score.ToString() : "Not this time!";
        string totalString = totalScore.ToString();
        string moodString =  "Overall Mood:\n" + moodStringC;

        pointUiParent.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = r1String;
        pointUiParent.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = r2String;
        pointUiParent.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = r3String;
        pointUiParent.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = r4String;
        pointUiParent.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = totalString;
        pointUiParent.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = moodString;

        yield return new WaitForSeconds(displayWait);
        pointUiParent.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(displayWait);
        pointUiParent.transform.GetChild(1).gameObject.SetActive(true);

        yield return new WaitForSeconds(displayWait);
        pointUiParent.transform.GetChild(2).gameObject.SetActive(true);

        yield return new WaitForSeconds(displayWait);
        pointUiParent.transform.GetChild(3).gameObject.SetActive(true);

        yield return new WaitForSeconds(displayWait);
        pointUiParent.transform.GetChild(4).gameObject.SetActive(true);

        yield return new WaitForSeconds(displayWait);
        pointUiParent.transform.GetChild(5).gameObject.SetActive(true);

        source.Play();

        

    }

}
