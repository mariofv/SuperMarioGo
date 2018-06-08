using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {

    public float speed;
    public float maxHeight;

    private Vector3 originalPosition;
	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float height = Mathf.Sin(Time.fixedTime * speed) * maxHeight;
        transform.position = originalPosition + Vector3.up * height;
	}
}
