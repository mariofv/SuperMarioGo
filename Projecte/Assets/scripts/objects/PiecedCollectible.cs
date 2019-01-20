using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecedCollectible : MonoBehaviour {

    private Enums.CollectibleType collectibleType;
    private GameObject prefab;
    private GameObject instantiadedObject;

    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setCollectibleType(Enums.CollectibleType collectibleType)
    {
        this.collectibleType = collectibleType;
        instantiatePrefab();
        selectFragments();

    }

private void instantiatePrefab()
    {

        string prefabPath = "prefabs/scenario/objects/collectibles/piecemade/";
        switch (collectibleType)
        {
            case Enums.CollectibleType.MUSHROOM:
                prefabPath += "Mushroom/CollectibleMushroom";
                break;
            case Enums.CollectibleType.STAR:
                prefabPath += "Star/CollectibleStar";
                break;
            case Enums.CollectibleType.YOSHI:
                prefabPath += "YoshiEgg/CollectibleYoshiEgg";
                break;
            default:
                throw new System.Exception("IMPOSIBLE MODEL!");
        }
        prefab = Resources.Load(prefabPath) as GameObject;
        instantiadedObject = Instantiate(prefab, transform) as GameObject;
    }

    private void selectFragments()
    {
        MeshRenderer meshRenderer = instantiadedObject.GetComponent<MeshRenderer>();

        Material mat;
        Material defaultMat = Resources.Load("prefabs/scenario/objects/collectibles/piecemade/UknownPieceMaterial") as Material; 
        List<bool> pieces;
        switch (collectibleType)
        {
            case Enums.CollectibleType.MUSHROOM:
                pieces = DataController.instance.getMushroomCollectibleData();
                mat = Resources.Load("prefabs/scenario/objects/collectibles/piecemade/Mushroom/shroomMat") as Material;
                break;
            case Enums.CollectibleType.STAR:
                pieces = DataController.instance.getStarCollectibleData();
                mat = Resources.Load("prefabs/scenario/objects/collectibles/piecemade/Star/mat_star") as Material;
                break;
            case Enums.CollectibleType.YOSHI:
                pieces = DataController.instance.getYoshiCollectibleData();
                mat = Resources.Load("prefabs/scenario/objects/collectibles/piecemade/YoshiEgg/YoshiEggMaterial") as Material;
                break;
            default:
                throw new System.Exception("IMPOSIBLE MODEL!");
        }

        Material[] currentMaterials = meshRenderer.sharedMaterials;
        for (int i = 0; i < 3; ++i)
        {
            if (pieces[i])
            {
                currentMaterials[i] = mat;
            }
            else
            {
                currentMaterials[i] = defaultMat;
            }
        }

        meshRenderer.sharedMaterials = currentMaterials;
    }
}
