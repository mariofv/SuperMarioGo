using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {

    public Text infoText;


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 getPosition()
    {
        return transform.localPosition;
    }

    public void fillInfo(string info)
    {
        infoText.text = info;
    }
}
