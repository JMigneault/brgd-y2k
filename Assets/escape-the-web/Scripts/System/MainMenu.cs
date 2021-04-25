using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("etwFinalScene");
    }

    public void exitGame() {
        SceneManager.LoadScene("ovMainMenu");
    }
}