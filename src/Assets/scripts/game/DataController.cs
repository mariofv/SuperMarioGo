using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;                                                       

public class DataController : MonoBehaviour
{
    public static DataController instance;

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

        filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        loadGameData();
    }

    private SaveState playerProgress;
    private string gameDataFileName = "data.json";
    private string filePath;

    void Start()
    {     
    }


    private void loadGameData()
    {

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            playerProgress = JsonUtility.FromJson<SaveState>(dataAsJson);
        }
        else
        {
            playerProgress = new SaveState();
            saveGameData();
        }
    }
    
    public void saveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(playerProgress);
        File.WriteAllText(filePath, dataAsJson);
    }

    public void collectCollectible(Enums.CollectibleType collectibleType, int piece)
    {
        switch (collectibleType)
        {
            case Enums.CollectibleType.COIN:
                playerProgress.coinCollectibleAmount[piece] = true;
                break;
            case Enums.CollectibleType.STARBIT:
                playerProgress.starBitCollectibleAmount[piece] = true;
                break;
            case Enums.CollectibleType.STARCHIP:
                playerProgress.starChipCollectibleAmount[piece] = true;
                break;
            case Enums.CollectibleType.MUSHROOM:
                playerProgress.mushroomCollectibleAmount[piece] = true;
                break;
            case Enums.CollectibleType.STAR:
                playerProgress.starCollectibleAmount[piece] = true;
                break;
            case Enums.CollectibleType.YOSHI:
                playerProgress.yoshiCollectibleAmount[piece] = true;
                break;
            default:
                throw new System.Exception("This should never happen!");
        }

        saveGameData();
    }

    public List<bool> getCoinCollectibleData()
    {
        return playerProgress.coinCollectibleAmount;
    }

    public List<bool> getStarBitCollectibleData()
    {
        return playerProgress.starBitCollectibleAmount;
    }

    public List<bool> getStarChipCollectibleData()
    {
        return playerProgress.starChipCollectibleAmount;
    }

    public List<bool> getMushroomCollectibleData()
    {
        return playerProgress.mushroomCollectibleAmount;
    }

    public List<bool> getStarCollectibleData()
    {
        return playerProgress.starCollectibleAmount;
    }

    public List<bool> getYoshiCollectibleData()
    {
        return playerProgress.yoshiCollectibleAmount;
    }
}