using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionMenu : Menu {

    private Scroll3DMenu scrollMenu;
    private Elevator elevator;

	// Use this for initialization
	void Start () {
        scrollMenu = GetComponentInChildren<Scroll3DMenu>();
        elevator = GetComponent<Elevator>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public override void leftKeyPressed()
    {
        if (ready())
        {
            scrollMenu.scrollLeft();
            SoundManager.instance.playMusicEffect(arrowKeyPressedEffect);
        }
    }

    public override void rightKeyPressed()
    {
        if (ready())
        {
            scrollMenu.scrollRight();
            SoundManager.instance.playMusicEffect(arrowKeyPressedEffect);
        }
    }

    public override void enterKeyPressed()
    {

    }

    public override void openMenu()
    {
        elevator.descend();
    }

    public override void closeMenu()
    {
        elevator.ascend();
    }

    private bool ready()
    {
        return scrollMenu.ready() && elevator.ready();
    }
}
