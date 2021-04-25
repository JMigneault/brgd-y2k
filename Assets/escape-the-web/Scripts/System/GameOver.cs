using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void toMainMenu() {
        SceneManager.LoadScene("etwStart");
    }

    public void exitGame() {
        SceneManager.LoadScene("ovMainMenu");
    }
}