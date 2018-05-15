using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour {

    public MenuButtonRulette menuButtonRoulette;
    public MenuText menuText;
    public AudioSource menuMusic;
   

    // Use this for initialization
    void Start () {
        menuText.setText(menuButtonRoulette.getCurrentButtonName());
    }


    void Update()
    {
      
    }

    public void previousButton()
    {
        if (!menuText.swaping())
        { 
            menuButtonRoulette.rotateLeft();
            menuText.swapText(menuButtonRoulette.getCurrentButtonName());
            menuMusic.Play();
        }
    }

    public void nextButton()
    {
        if (!menuText.swaping())
        {
            menuButtonRoulette.rotateRight();
            menuText.swapText(menuButtonRoulette.getCurrentButtonName());
            menuMusic.Play();
        }
    }
    


}
