using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenCollectible : MonoBehaviour {

    public Enums.CollectibleType collectibleType;
    public int pieceNumber;
    public AudioClip collectibleFound;

	// Use this for initialization
	void Start () {
		if (isCollected())
        {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameManager.instance.handleAction(new CollectibleCollectedAction(collectibleType, pieceNumber, collectibleFound));
            gameObject.SetActive(false);
        }
    }

    private bool isCollected()
    {
        List<bool> collectibleData;
        switch (collectibleType)
        {
            case Enums.CollectibleType.COIN:
                collectibleData = DataController.instance.getCoinCollectibleData();
                break;
            case Enums.CollectibleType.MUSHROOM:
                collectibleData = DataController.instance.getMushroomCollectibleData();
                break;
            case Enums.CollectibleType.STAR:
                collectibleData = DataController.instance.getStarCollectibleData();
                break;
            case Enums.CollectibleType.STARBIT:
                collectibleData = DataController.instance.getStarBitCollectibleData();
                break;
            case Enums.CollectibleType.STARCHIP:
                collectibleData = DataController.instance.getStarChipCollectibleData();
                break;
            case Enums.CollectibleType.YOSHI:
                collectibleData = DataController.instance.getYoshiCollectibleData();
                break;
            default:
                throw new System.Exception("This should never happen!");
        }

        return collectibleData[pieceNumber];
    }
}
