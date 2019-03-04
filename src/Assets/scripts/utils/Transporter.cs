using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    private Transform objTransform;
    private Vector3 origin, destination;
    public float speed;
    private float currentProgress;
    private float distance;
    private bool moving, transporting;

    void Start()
    {
        objTransform = GetComponent<Transform>();
        moving = false;
    }

    void Update()
    {
        if (moving)
        {
            currentProgress += Time.deltaTime * speed;
            float step = currentProgress / distance;
            objTransform.position = Vector3.Lerp(origin, destination, step);
            if (objTransform.position == destination)
            {
               stop();
            }
        }
    }

    public void move(Vector3 origin, Vector3 destination, AudioClip clip1 = null, AudioClip clip2 = null)
    {
        if (clip1 != null && clip2 != null)
        {
            SoundManager.instance.playSteps(clip1, clip2);
        }
        
        this.origin = origin;
        this.destination = destination;
        distance = Vector3.Distance(origin, destination);
        moving = true;
        currentProgress = 0;
    }

    public void stop()
    {
        moving = false;
        SoundManager.instance.stopSteps();
    }

    public bool isMoving()
    {
        return moving;
    }
}
