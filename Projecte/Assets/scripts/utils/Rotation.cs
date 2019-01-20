using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float rotationSpeed;
    public bool fixRotation;

    private Quaternion rotation;
    private float lastSpeed;

	// Use this for initialization
	void Start () {
        rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (!fixRotation)
        {
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }
    }

    public void disable()
    {
        transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        lastSpeed = rotationSpeed;
        rotationSpeed = 0;
    }

    public void enable()
    {
        rotationSpeed = lastSpeed;

    }

    void LateUpdate()
    {
        if (fixRotation)
        {
            transform.rotation = rotation;
        }    
    }
}
