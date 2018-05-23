using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu {

    private MenuButtonRulette menuButtonRoulette;
    private MainMenuText menuText;

    // Use this for initialization
    void Start () {
        menuButtonRoulette = GetComponentInChildren<MenuButtonRulette>();
        menuText = GetComponentInChildren<MainMenuText>();
        menuText.setText(menuButtonRoulette.getCurrentButtonName());
    }

    // Update is called once per frame
    void Update () {
		
	}

    public override void leftKeyPressed()
    {
        if (ready())
        {
            menuButtonRoulette.rotateLeft();
            menuText.swapText(menuButtonRoulette.getCurrentButtonName(), true);
            SoundManager.instance.playMusicEffect(arrowKeyPressedEffect);
        }
    }

    public override void rightKeyPressed()
    {
        if (ready())
        {
            menuButtonRoulette.rotateRight();
            menuText.swapText(menuButtonRoulette.getCurrentButtonName(), false);
            SoundManager.instance.playMusicEffect(arrowKeyPressedEffect);
        }
    }

    public override void enterKeyPressed()
    {
        if (ready())
        {
            MenuManager.instance.openSubMenu(menuButtonRoulette.getCurrentButtonSubMenu());
        }
    }

    public override void closeMenu()
    {
        GetComponent<Animator>().SetBool("focus", true);
        menuButtonRoulette.focusCurrentButton();
        menuText.disable();
    }

    public override void openMenu()
    {
        GetComponent<Animator>().SetBool("focus", false);
        menuButtonRoulette.disfocusCurrentButton();
        menuText.enable();
    }

    private bool ready()
    {
        return !menuText.swaping() && !menuButtonRoulette.isRotating();
    }


}
