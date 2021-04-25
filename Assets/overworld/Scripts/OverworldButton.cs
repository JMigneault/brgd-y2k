using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldButton : MonoBehaviour
{

    public string sceneName;

    public void OverworldLoadScene() {
        SceneManager.LoadScene(sceneName);
    }

}
