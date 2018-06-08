using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu {

    private MenuButtonRulette menuButtonRoulette;
    private MainMenuText menuText;
    public GameObject menuButtonRouletteObject;
    public GameObject backgroundLogo;
    public GameObject enterInfo;
    public GameObject arrowInfo;


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
            SoundManager.instance.playMusicEffect(enterKeyPressedEffect);
            MenuManager.instance.openSubMenu(menuButtonRoulette.getCurrentButtonSubMenu());
        }
    }

    public override void closeMenu()
    {
        menuButtonRouletteObject.SetActive(false);
        menuText.disable();
        backgroundLogo.SetActive(false);
        enterInfo.SetActive(false);
        arrowInfo.SetActive(false);
    }

    public override void openMenu()
    {
        menuButtonRouletteObject.SetActive(true);
        menuText.enable();
        backgroundLogo.SetActive(true);
        enterInfo.SetActive(true);
        arrowInfo.SetActive(true);
    }

    private bool ready()
    {
        return !menuText.swaping() && !menuButtonRoulette.isRotating();
    }


}
