using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : Menu
{
    private Scroll3DMenu scrollMenu;
    private int currentLevel;
    public List<string> levels;
    private bool changing;

    // Use this for initialization
    void Start()
    {
        scrollMenu = GetComponentInChildren<Scroll3DMenu>();
        currentLevel = 0;
        changing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (changing)
        {
            if (SoundManager.instance.ready())
            {
                SceneLoader.instance.loadScene(levels[currentLevel]);
            }
        }
    }

    public override void leftKeyPressed()
    {
        if (ready() && scrollMenu.canScrollLeft())
        {
            --currentLevel;
            scrollMenu.scrollLeft();
            SoundManager.instance.playMusicEffect(arrowKeyPressedEffect);
        }
    }

    public override void rightKeyPressed()
    {
        if (ready() && scrollMenu.canScrollRight())
        {
            ++currentLevel;
            scrollMenu.scrollRight();
            SoundManager.instance.playMusicEffect(arrowKeyPressedEffect);
        }
    }

    public override void enterKeyPressed()
    {
        if (ready())
        {
            SoundManager.instance.playMusicEffect(enterKeyPressedEffect);
            changing = true;
        }
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
        return scrollMenu.ready() && !changing;
    }
    
}
