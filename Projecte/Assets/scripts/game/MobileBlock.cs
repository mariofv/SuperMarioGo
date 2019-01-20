using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileBlock : MonoBehaviour {

    public Transform currentNode;
    public Transform Node;
    private Transform bloc;
    private bool start, moving, movecharacter;

    private Vector3 startPosition, endPosition;
    private Vector3 origin, destination;
    private Vector3 origincharacter, destinationcharacter;
    public float speed;
    private float distance;
    private float currentProgress;

    // Use this for initialization
    void Start () {
        bloc = GetComponent<Transform>();
        start = true;
        moving = false;
        movecharacter = false;

        startPosition = bloc.position;
        endPosition = Node.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            moveBloc();
            if (movecharacter) moveCharacter();
        }
    }

    public void moveblocks()
    {
        moving = true;
        currentProgress = 0;
        currentNode.gameObject.SetActive(false);
        Node.gameObject.SetActive(false);

        if (CharacterManager.instance.getCharacterNextPosition() == bloc.GetChild(1).position)
        {
            movecharacter = true;
        }

        if (start)
        {
            origin = startPosition;
            destination = endPosition;

        }

        else
        {
            origin = endPosition;
            destination = startPosition;
        }


        origincharacter = origin;
        origincharacter.y += 2.5f;

        destinationcharacter = destination;
        destinationcharacter.y += 2.5f;

        distance = Vector3.Distance(origin, destination);

    }

    private void moveBloc()
    {
        currentProgress += Time.deltaTime * speed;
        float step = currentProgress / distance;
        bloc.position = Vector3.Lerp(origin, destination, step);
        if (bloc.position == destination)
        {
            moving = false;
            if (start)
            {
                currentNode.gameObject.SetActive(false);
                Node.gameObject.SetActive(true);
                start = false;
                if (movecharacter)
                {
                    GameManager.instance.setCurrentNode(Node.GetChild(1).GetChild(0).gameObject);
                    movecharacter = false;
                }
            }
            else
            {
                currentNode.gameObject.SetActive(true);
                Node.gameObject.SetActive(false);
                start = true;
                if (movecharacter)
                {
                    GameManager.instance.setCurrentNode(currentNode.GetChild(1).GetChild(0).gameObject);
                    movecharacter = false;
                }
            }

           
        }
    }

    public bool ready()
    {
        return !moving;
    }

    private void moveCharacter()
    {
        float step = currentProgress / distance;
        CharacterManager.instance.setCharacterPosition(Vector3.Lerp(origincharacter, destinationcharacter, step));
    }
}
