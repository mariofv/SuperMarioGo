using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    public float rotationSpeed = 10f;

    public GameObject model;
    public Transform leftPoint;
    public Transform rightPoint;

    private GameObject buttonModel;

    // Use this for initialization
    void Start () {
        buttonModel = Instantiate(model, gameObject.transform);


    }
	
	// Update is called once per frame
	void Update () {
        buttonModel.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
