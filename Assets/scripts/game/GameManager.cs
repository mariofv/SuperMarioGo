using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
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

    public GameObject startNode;
    public GameObject goalNode;
    public string nextLevel;

    private GameObject currentNode;
    private bool pendingIteration;
    private bool finishLevel;
    private bool resetedLevel;

    void Start()
    {
        currentNode = startNode;
        CharacterManager.instance.setCharacterPosition(currentNode.transform.parent);
        pendingIteration = false;
        finishLevel = false;
        resetedLevel = false;
    }

    //Update is called every frame.
    void Update()
    {
        if (finishLevel && allEntititesReady())
        {
            SceneLoader.instance.loadScene(nextLevel);   
        }
        if (resetedLevel && allEntititesReady())
        {
            SceneLoader.instance.reloadScene();
        }
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
        finishLevel = currentNode == goalNode;
        if (finishLevel)
        {
            SoundManager.instance.playVictoryMusic();
            CharacterManager.instance.celebrateVictory();
        }
    }

    public void enterPipe()
    {
        SpecialBlockManager.instance.enterPipe(currentNode);
    }

    public void resetLevel()
    {
        resetedLevel = true;
    }

    private bool allEntititesReady()
    {
        return CharacterManager.instance.ready() && SoundManager.instance.ready() && Fire.instance.ready() && SpecialBlockManager.instance.allSpecialBlocksReady() && EnemyManager.instance.allEnemiesReady() && ScenarioManager.instance.ready();
    }

    private void iterateScenario()
    {
        ScenarioManager.instance.moveAllBlocks();
        EnemyManager.instance.moveEnemies();
    }


}