using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{

    public string LevelToLoad;

	public void loadLevel() {
		//Load the level from LevelToLoad
		SceneManager.LoadScene(LevelToLoad);
	}

}
