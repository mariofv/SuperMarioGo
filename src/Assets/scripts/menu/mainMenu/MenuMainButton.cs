using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMainButton : MonoBehaviour {

    public GameObject model;
    public string buttonName;
    public float modelScale;
    public Menu subMenu;

    private GameObject buttonModel;

    // Use this for initialization
    void Start () {
        buttonModel = Instantiate(model, gameObject.transform);
        buttonModel.transform.localScale = new Vector3(modelScale, modelScale, modelScale);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
