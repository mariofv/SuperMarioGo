using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiRotation : MonoBehaviour {

    public float speed;
    public float maxAngle;

    private Quaternion originalRotation;

	// Use this for initialization
	void Start () {
        originalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = originalRotation;
        float angle = Mathf.Sin(Time.fixedTime * speed) * maxAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
	}
}
