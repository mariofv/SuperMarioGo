using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public GameObject currentNode;

    private bool pendingIteration;

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

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        CharacterManager.instance.setCharacterPosition(currentNode.transform.parent);
        pendingIteration = false;
    }

    //Update is called every frame.
    void Update()
    {
        if (pendingIteration && allEntititesReady())
        {
            iterateScenario();
            pendingIteration = false;
        }
    }

    public void handleAction(Action action)
    {
        if (allEntititesReady())
        {
            action.execute();
            pendingIteration = action.triggersIteration();
        }
    }

    public GameObject getCurrentNode()
    {
        return currentNode;
    }

    public void setCurrentNode(GameObject currentNode)
    {
        this.currentNode = currentNode;
    }

    private bool allEntititesReady()
    {
        return CharacterManager.instance.ready();
    }

    private void iterateScenario()
    {

    }
}