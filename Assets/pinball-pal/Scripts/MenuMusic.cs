using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioSource musicSourceInitial;
	public AudioSource musicSourceLoop;
	private float initialMusicLength = 12.05f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayMusicLoop", initialMusicLength);
    }

    void PlayMusicLoop()
    {
        musicSourceLoop.Play();
    }
}
