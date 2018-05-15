using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuKeyboardManager : MonoBehaviour {

    public MenuManager menuManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            menuManager.previousButton();
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            menuManager.nextButton();
        }
    }
}
