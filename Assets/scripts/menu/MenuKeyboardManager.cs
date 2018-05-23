using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuKeyboardManager : MonoBehaviour {

    private MenuManager menuManager;

	// Use this for initialization
	void Start () {
        menuManager = GetComponent<MenuManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            menuManager.leftKeyPressed();
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            menuManager.rightKeyPressed();
        }
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            menuManager.enterKeyPressed();
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            menuManager.escapeKeyPressed();
        }
    }
}
