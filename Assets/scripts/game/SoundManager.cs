using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    private AudioSource effectSource;
    private AudioSource marioSource;
    private AudioSource backgroundMusicSource;

    private EndMusic endMusic;
    private StepEffect stepEffect;

    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    // Use this for initialization
    void Start () {
        backgroundMusicSource = transform.GetChild(0).GetComponent<AudioSource>();
        effectSource = transform.GetChild(1).GetComponent<AudioSource>();
        marioSource = transform.GetChild(3).GetComponent<AudioSource>();
        endMusic = GetComponentInChildren<EndMusic>();
        stepEffect = GetComponentInChildren<StepEffect>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playMusicEffect(AudioClip effect)
    {
        if (effectSource.isPlaying)
        {
            effectSource.Stop();
        }
        effectSource.clip = effect;
        effectSource.Play();
    }

    public void playMarioEffect(AudioClip effect)
    {
        if (marioSource.isPlaying)
        {
            marioSource.Stop();
        }
        marioSource.clip = effect;
        marioSource.Play();
    }

    public void playSteps(AudioClip c1, AudioClip c2)
    {
        stepEffect.playSteps(c1, c2);
    }

    public void stopSteps()
    {
        stepEffect.stopSteps();
    }

    public void playVictoryMusic()
    {
        backgroundMusicSource.Stop();
        endMusic.playVictory();
    }

    public void playDefeatMusic()
    {
        backgroundMusicSource.Stop();
        endMusic.playDefeat();
    }

    public void playPauseMusic()
    {
        backgroundMusicSource.Stop();
        endMusic.playReset();
    }

    public bool ready()
    {
        return !effectSource.isPlaying && !marioSource.isPlaying && endMusic.ready();
    }
}
