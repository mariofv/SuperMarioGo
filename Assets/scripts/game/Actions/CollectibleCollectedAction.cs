using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollectedAction : Action {
    private int pieceNumber;
    private Enums.CollectibleType collectibleType;
    private AudioClip audio;

    public CollectibleCollectedAction(Enums.CollectibleType collectibleType, int pieceNumber, AudioClip audio)
    {
        this.collectibleType = collectibleType;
        this.pieceNumber = pieceNumber;
        this.audio = audio;
    }

    public override void execute()
    {
        DataController.instance.collectCollectible(collectibleType, pieceNumber);
        CollectiblePopup.instance.showPopUp(pieceNumber, collectibleType);
        SoundManager.instance.playMusicEffect(audio);
    }

    public override bool triggersIteration()
    {
        return false;
    }
    
    
}
