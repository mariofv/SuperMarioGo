using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance = null;
    
    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public Menu currentMenu;
    public Menu previousMenu;

    // Use this for initialization
    void Start () {
    }


    void Update()
    {
      
    }

    public void leftKeyPressed()
    {
        currentMenu.leftKeyPressed();
    }

    public void rightKeyPressed()
    {
        currentMenu.rightKeyPressed();
    }

    public void enterKeyPressed()
    {
        currentMenu.enterKeyPressed();
    }

    public void escapeKeyPressed()
    {
        if (previousMenu == null)
        {
            return;
        }
        currentMenu.closeMenu();
        currentMenu = previousMenu;
        previousMenu = null;
        currentMenu.openMenu();
    }

    public void openSubMenu(Menu subMenu)
    {
        currentMenu.closeMenu();
        previousMenu = currentMenu;
        currentMenu = subMenu;
        currentMenu.openMenu();
    }

}
