using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState
{
    public List<bool> coinCollectibleAmount;
    public List<bool> starChipCollectibleAmount;
    public List<bool> starBitCollectibleAmount;

    public List<bool> mushroomCollectibleAmount;
    public List<bool> starCollectibleAmount;
    public List<bool> yoshiCollectibleAmount;

    public List<int> maxLevelUnlocked;

    public SaveState()
    {
        coinCollectibleAmount = new List<bool>();
        starChipCollectibleAmount = new List<bool>();
        starBitCollectibleAmount = new List<bool>();

        mushroomCollectibleAmount = new List<bool>();
        starCollectibleAmount = new List<bool>();
        yoshiCollectibleAmount = new List<bool>();

        for (int i = 0; i < 3; ++i)
        {
            mushroomCollectibleAmount.Add(false);
            starCollectibleAmount.Add(false);
            yoshiCollectibleAmount.Add(false);

            coinCollectibleAmount.Add(false);
            starChipCollectibleAmount.Add(false);
            starBitCollectibleAmount.Add(false);
        }

        List<int> maxLevelUnlocked = new List<int>();
        maxLevelUnlocked.Add(1);
        maxLevelUnlocked.Add(0);
        maxLevelUnlocked.Add(0);
    }
}
