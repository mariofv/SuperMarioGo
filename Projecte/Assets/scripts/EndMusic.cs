using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusic : MonoBehaviour {

    public AudioClip victory;
    public AudioClip defeat;
    public AudioClip reset;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playDefeat()
    {
        audioSource.clip = defeat;
        audioSource.Play();
    }

    public void playVictory()
    {
        audioSource.clip = victory;
        audioSource.Play();
    }

    public void playReset()
    {
        audioSource.clip = reset;
        audioSource.Play();
    }

    public bool ready()
    {
        return !audioSource.isPlaying;
    }


}
