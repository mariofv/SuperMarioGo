using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    enum CharacterState
    {
        IDLE,
        WALKING,
        START_CLIMBING_UP,
        STOP_CLIMBING_UP,
        START_CLIMBING_DOWN,
        STOP_CLIMBING_DOWN,
        CLIMBING_IDLE,
        CLIMBING_UP,
        CLIMBING_DOWN,
        CLIMBING_LEFT,
        CLIMBING_RIGHT,
    };

    public static CharacterManager instance = null;

    public int walkingSpeed;

    private CharacterState characterState;
    private Transform characterTransform;
    private Transform destinationTransform;

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

    void Start()
    {
        characterState = CharacterState.IDLE;
        characterTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (characterState)
        {
            case CharacterState.WALKING:
                walk();
                break;
        }
    }

    public void setCharacterPosition(Transform transform)
    {
        characterTransform.position = transform.position;
    }

    public void moveCharacter(Transform currentNode, Transform node)
    {
        setState(currentNode, node);
        //TODO: Aqui hay que activar la animacion, pendiendte de discutir

       
        faceCharacter(currentNode, node);
        destinationTransform = node;
    }

    public bool ready()
    {
        return characterState == CharacterState.IDLE || characterState == CharacterState.CLIMBING_IDLE;
    }

    private void setState(Transform currentNode, Transform node)
    {
        int heightDifference = (int)Mathf.Round(node.position.y - currentNode.position.y);
        Debug.Log(heightDifference);
        switch (characterState)
        {
            case CharacterState.IDLE:
                if (heightDifference == 0)
                {
                    characterState = CharacterState.WALKING;
                }
                else if (heightDifference > 0)
                {
                    characterState = CharacterState.START_CLIMBING_UP;
                }
                else
                {
                    characterState = CharacterState.START_CLIMBING_DOWN;
                }
                break;
            case CharacterState.CLIMBING_IDLE:
               //TODO: THIS
                break;
        }
    }

    private void faceCharacter(Transform currentNode, Transform node)
    {
        Vector3 dir = new Vector3(node.position.x - currentNode.position.x, 0, node.position.z - currentNode.position.z);
        characterTransform.rotation = Quaternion.LookRotation(dir);
    }

    private void walk()
    {
        float step = Time.deltaTime * walkingSpeed;
        characterTransform.position = Vector3.Lerp(characterTransform.position, destinationTransform.position, step);

        if (Vector3.Distance(characterTransform.position, destinationTransform.position) < 0.01)
        {
            characterTransform.position = destinationTransform.position;
            characterState = CharacterState.IDLE;

        }
    }

    private void climb()
    {
    }
}
