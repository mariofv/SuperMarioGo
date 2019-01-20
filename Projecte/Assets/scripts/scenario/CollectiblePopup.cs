using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblePopup : MonoBehaviour {

    public static CollectiblePopup instance = null;
   
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

    public Text infoText;
    public GameObject modelSlot;
    public GameObject canvas;
    public GameObject instantiatedObject;

    private bool showing;

    // Use this for initialization
    void Start () {
        showing = false;

    }
	
	// Update is called once per frame
	void Update () {
		if (showing && Input.anyKey)
        {
            canvas.SetActive(false);
            Destroy(instantiatedObject);
            showing = false;
        }
	}
    

    public void showPopUp(int pieceNumber, Enums.CollectibleType collectibleType)
    {
        infoText.text = getCollectibleText(collectibleType);
        instantiateModel(collectibleType, pieceNumber);
        canvas.SetActive(true);
        showing = true;
    }

    private string getCollectibleText(Enums.CollectibleType collectibleType)
    {
        string text; 

        switch (collectibleType)
        {
            case Enums.CollectibleType.COIN:
                text = "COIN collected!";
                break;
            case Enums.CollectibleType.STARBIT:
                text = "STAR BIT collected!";
                break;
            case Enums.CollectibleType.STARCHIP:
                text = "STAR CHIP collected!";
                break;
            case Enums.CollectibleType.MUSHROOM:
                text = "MUSHROOM \n fragment collected!";
                break;
            case Enums.CollectibleType.STAR:
                text = "STAR \n fragment collected!";
                break;
            case Enums.CollectibleType.YOSHI:
                text = "YOSHI \n fragment collected!";
                break;
            default:
                throw new System.Exception("This should never happen!");
        }

        return text;
    }

    private void instantiateModel(Enums.CollectibleType collectibleType, int pieceNumber)
    {
        string path = "prefabs/scenario/objects/collectibles/";
        bool isPieced = false;
        switch (collectibleType)
        {
            case Enums.CollectibleType.COIN:
                path += "Coin";
                break;
            case Enums.CollectibleType.STARBIT:
                path += "Star Bit";
                break;
            case Enums.CollectibleType.STARCHIP:
                path += "Star Chip";
                break;
            case Enums.CollectibleType.MUSHROOM:
                path += "piecemade/Pieced Collectible";
                isPieced = true;
                break;
            case Enums.CollectibleType.STAR:
                path += "piecemade/Pieced Collectible";
                isPieced = true;
                break;
            case Enums.CollectibleType.YOSHI:
                path += "piecemade/Pieced Collectible";
                isPieced = true;
                break;
            default:
                throw new System.Exception("This should never happen");
        }

        GameObject prefab = Resources.Load(path) as GameObject;
        instantiatedObject = Instantiate(prefab, modelSlot.transform);

        if (isPieced)
        {
            instantiatedObject.GetComponent<PiecedCollectible>().setCollectibleType(collectibleType);
        }
    }

}
