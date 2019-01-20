using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelKeyboardManager : MonoBehaviour {

    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            gameManager.handleAction(new DirectionPressedAction(Enums.Direction.LEFT));
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            gameManager.handleAction(new DirectionPressedAction(Enums.Direction.RIGHT));
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            gameManager.handleAction(new DirectionPressedAction(Enums.Direction.UP));
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            gameManager.handleAction(new DirectionPressedAction(Enums.Direction.DOWN));
        }
        else if (Input.GetKeyUp(KeyCode.Space) && CharacterManager.instance.isIdle())
        {
            gameManager.handleAction(new PowerPressedAction(Enums.Power.JUMP));
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            gameManager.handleAction(new PowerPressedAction(Enums.Power.FIRE));
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            SoundManager.instance.playPauseMusic();
            gameManager.resetLevel();
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneLoader.instance.loadScene("mainMenu");
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            CharacterManager.instance.sayRandomThing();
        }
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            gameManager.handleAction(new PowerPressedAction(Enums.Power.ENTER));
        }
    }
}
