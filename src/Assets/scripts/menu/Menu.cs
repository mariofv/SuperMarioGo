using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour {

    public AudioClip arrowKeyPressedEffect;
    public AudioClip enterKeyPressedEffect;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract void leftKeyPressed();
    public abstract void rightKeyPressed();
    public abstract void enterKeyPressed();
    public abstract void openMenu();
    public abstract void closeMenu();
}
