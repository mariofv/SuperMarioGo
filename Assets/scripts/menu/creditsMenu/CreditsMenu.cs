using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMenu : Menu {
    

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
    }

    public override void leftKeyPressed()
    {
        
    }

    public override void rightKeyPressed()
    {
        
    }

    public override void enterKeyPressed()
    {

    }

    public override void openMenu()
    {
        gameObject.SetActive(true);
    }

    public override void closeMenu()
    {
        gameObject.SetActive(false);
    }


    private bool ready()
    {
        return true;
    }
    
}
