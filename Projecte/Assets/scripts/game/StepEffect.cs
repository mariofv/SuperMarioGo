using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepEffect : MonoBehaviour {

    public float speed;

    private bool steping;
    private AudioClip c1;
    private AudioClip c2;
    private bool stepClip;
    private float currentTime;

    private AudioSource effectSource;

    // Use this for initialization
    void Start () {
        effectSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (steping)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 1/speed)
            {
                currentTime = 0;
                stepClip = !stepClip;
                if (stepClip)
                {
                    effectSource.clip = c1;
                }
                else
                {
                    effectSource.clip = c2;
                }
                effectSource.Play();
            }
        }

    }

    public void playSteps(AudioClip c1, AudioClip c2)
    {
        if (effectSource.isPlaying)
        {
            effectSource.Stop();
        }
        this.c1 = c1;
        this.c2 = c2;
        steping = true;
        stepClip = true;
        currentTime = 0;
    }

    public void stopSteps()
    {
        steping = false;
    }
}
