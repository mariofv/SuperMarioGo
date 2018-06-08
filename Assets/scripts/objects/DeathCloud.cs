using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCloud : MonoBehaviour {
    public static DeathCloud instance = null;
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

    public Vector3 hiddenPosition;
    private bool animated;
    private ParticleSystem particleSystem;

    // Use this for initialization
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (animated)
        {
            if (!particleSystem.isEmitting)
            {
                hide();
            }
        }
    }

    public void activate(Vector3 position)
    {
        transform.position = position;
        animated = true;
        particleSystem.Play();
    }

    public bool ready()
    {
        return !animated;
    }

    private void hide()
    {
        particleSystem.Stop();
        transform.position = hiddenPosition;
        animated = false;
    }
 
}
