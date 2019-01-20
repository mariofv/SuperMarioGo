using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportPipe : SpecialBlock {

    public TransportPipe connectedPipe;
    public GameObject node;
    public float speed;
    public GameObject hole;
    public GameObject transport;
    public AudioClip sound;

    private Vector3 holePosition;
    private Vector3 transportPosition;
    private float currentProgress;
    private float distance;
    private bool suckingCharacter;
    private bool spitingCharacter;

    // Use this for initialization
    void Start () {
        holePosition = hole.transform.position;
        transportPosition = transport.transform.position;
        distance = Mathf.Abs(holePosition.y - transportPosition.y);
        suckingCharacter = false;
        spitingCharacter = false;

    }
	
	// Update is called once per frame
	void Update () {

		if (suckingCharacter) {

            suckCharacter();
            if (!suckingCharacter)
            {
                GameManager.instance.setCurrentNode(connectedPipe.node);
                CharacterManager.instance.setCharacterPosition(connectedPipe.transportPosition);
                connectedPipe.spitingCharacter = true;
                connectedPipe.currentProgress = 0;
                SoundManager.instance.playMusicEffect(sound);

            }
        }

        if (spitingCharacter)
        {
            spitCharacter();
            if (!spitingCharacter)
            {
                CharacterManager.instance.resumeAnimation();
                CharacterManager.instance.setCharacterPosition(node.transform.position);
            }
        }

	}

    public void enter(GameObject currentNode)
    {
        if (node == currentNode)
        {
            currentProgress = 0;
            CharacterManager.instance.setCharacterPosition(holePosition);
            CharacterManager.instance.pauseAnimation();
            suckingCharacter = true;
            SoundManager.instance.playMusicEffect(sound);
        }
    }

    private void suckCharacter()
    {
        currentProgress += Time.deltaTime*speed;
        float step = currentProgress / distance;
        Vector3 newPosition = Vector3.Lerp(holePosition, transportPosition, step);
        CharacterManager.instance.setCharacterPosition(newPosition);
        if (newPosition == transportPosition)
        {
            suckingCharacter = false;
        }
    }

    private void spitCharacter()
    {
        currentProgress += Time.deltaTime * speed;
        float step = currentProgress / distance;
        Vector3 newPosition = Vector3.Lerp(transportPosition, holePosition, step);
        CharacterManager.instance.setCharacterPosition(newPosition);
        if (newPosition == holePosition)
        {
            spitingCharacter = false;
        }
    }

    public override bool ready()
    {
        return !suckingCharacter && !spitingCharacter;
    }
}
