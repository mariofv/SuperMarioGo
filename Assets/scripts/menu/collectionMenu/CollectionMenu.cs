using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionMenu : Menu {

    private Scroll3DMenu scrollMenu;
    public List<PiecedCollectible> piecemadeCollectibles;

	// Use this for initialization
	void Start () {
        scrollMenu = GetComponentInChildren<Scroll3DMenu>();
        fillMenuInfo();
    }

    // Update is called once per frame
    void Update () {
        
	}

    public override void leftKeyPressed()
    {
        if (ready() && scrollMenu.canScrollLeft())
        {
            scrollMenu.scrollLeft();
            SoundManager.instance.playMusicEffect(arrowKeyPressedEffect);
        }
    }

    public override void rightKeyPressed()
    {
        if (ready() && scrollMenu.canScrollRight())
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
        gameObject.SetActive(true);
    }

    public override void closeMenu()
    {
        gameObject.SetActive(false);
    }

    private void fillMenuInfo()
    {
        List<string> collectibleStrings = new List<string>();

        piecemadeCollectibles[0].setCollectibleType(Enums.CollectibleType.MUSHROOM);
        piecemadeCollectibles[1].setCollectibleType(Enums.CollectibleType.YOSHI);
        piecemadeCollectibles[2].setCollectibleType(Enums.CollectibleType.STAR);
        collectibleStrings.Add(getPieceCollectibleInfo(DataController.instance.getMushroomCollectibleData(), "Luigi"));
        collectibleStrings.Add(getPieceCollectibleInfo(DataController.instance.getYoshiCollectibleData(), "Peach"));
        collectibleStrings.Add(getPieceCollectibleInfo(DataController.instance.getStarCollectibleData(), "Mini Mario"));

        collectibleStrings.Add(getSimpleCollectibleInfo(DataController.instance.getCoinCollectibleData()));
        collectibleStrings.Add(getSimpleCollectibleInfo(DataController.instance.getStarChipCollectibleData()));
        collectibleStrings.Add(getSimpleCollectibleInfo(DataController.instance.getStarBitCollectibleData()));

        scrollMenu.setMenuButtonsInfo(collectibleStrings);

    }

    private bool ready()
    {
        return scrollMenu.ready();
    }

    private string getSimpleCollectibleInfo(List<bool> pieces)
    {
        int amount = 0;
        for (int i = 0; i < pieces.Count; ++i)
        {
            if (pieces[i])
            {
                ++amount;
            }
        }
        return amount + "/3 collected";
    }

    private string getPieceCollectibleInfo(List<bool> pieces, string character)
    {
        int amount = 0;
        for (int i = 0; i < pieces.Count; ++i)
        {
            if (pieces[i])
            {
                ++amount;
            }
        }

        string info = amount + "/3 fragments";
        if (amount == 42)
        {
            info += '\n' + character + " unlocked!";
        }
        return info;
    }
}
