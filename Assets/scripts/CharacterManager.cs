using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public List<AudioClip> jumpMario;
    public AudioClip jumpSound;
    public AudioClip step1;
    public AudioClip step2;
    public AudioClip climb1;
    public AudioClip climb2;
    public AudioClip shoot;
    public List<AudioClip> dying;
    public List<AudioClip> random;
    public AudioClip defeated;
    public AudioClip startClimbing;
    public AudioClip climbing;
    public AudioClip stopClimbing;
    
    private Vector3 nextPosition;

    public static CharacterManager instance = null;

    enum CharacterState
    {
        IDLE,
        DYING,
        WALKING,
        DEFAETED, 
        START_CLIMBING_UP,
        STOP_CLIMBING_UP,
        START_CLIMBING_DOWN,
        STOP_CLIMBING_DOWN,
        CLIMBING_IDLE,
        CLIMBING_UP,
        CLIMBING_DOWN,
        CLIMBING_SIDE,
        JUMPING,
        SHOT_FIREBALL,
        WINNING
    };

    Animator anim;

    private CharacterState characterState;
    private Transform characterTransform;
    private Transporter transporter;
    private Transform currentNode, goalNode;
    private bool win;
    private float currentAnimationSpeed;

    private Character character;

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
        anim = GetComponentInChildren<Animator> ();
        characterTransform = GetComponent<Transform>();
        transporter = GetComponent<Transporter>();
        character = GetComponentInChildren<Character>();
        characterState = CharacterState.IDLE;
        win = false;

    }

    // Update is called once per frame
    void Update()
    {
        switch (characterState)
        {
                
            case CharacterState.WALKING:
                if (!transporter.isMoving())
                {
                    if (win)
                    {
                        characterState = CharacterState.WINNING;
                        anim.Play("Dance");
                    }
                    else
                    {
                        characterState = CharacterState.IDLE;
                        anim.SetBool("walking", false);
                    }
                }
                break;
                
          
            case CharacterState.CLIMBING_UP:
                if (!transporter.isMoving())
                {
                    characterState = CharacterState.CLIMBING_IDLE;
                    anim.SetBool("climbUp", false);
                    anim.SetBool("idleHanging", true);
                }
                break;

            case CharacterState.CLIMBING_DOWN:
                if (!transporter.isMoving())
                {
                    characterState = CharacterState.CLIMBING_IDLE;
                    anim.SetBool("climbDown", false);
                    anim.SetBool("idleHanging", true);
                }
                break;

            case CharacterState.CLIMBING_SIDE:
                if (!transporter.isMoving())
                {
                    characterState = CharacterState.CLIMBING_IDLE;
                    anim.SetBool("climbSide", false);
                    anim.SetBool("idleHanging", true);
                }
                break;
               
        }

    }

    public void transport(GameObject nextNode, float speed, GameObject currentNode)
    {
        Vector3 initPos = new Vector3(0, currentNode.transform.position.y, 0);
        Vector3 goalPos = new Vector3(0, currentNode.transform.position.y - 5, 0);
        float currentProgress = 0;
        bool descending = true;

        while (descending)
        {
            currentProgress += speed * Time.deltaTime;
            float step = currentProgress / Mathf.Abs(goalPos.y - initPos.y);
            characterTransform.position = Vector3.Lerp(initPos, goalPos, step);

            if (Vector3.Distance(characterTransform.position, goalPos) == 0)
            {
                currentProgress = 0;
                descending = false;
            }
        }

        characterTransform.position = nextNode.transform.position;
        
    }

    public void setCharacterPosition(Transform transform)
    {
        characterTransform.position = transform.position;
    }

    public void setCharacterPosition(Vector3 pos)
    {
        characterTransform.position = pos;
    }

    public void faceCharacter(Transform currentNode, Transform node)
    {
        Vector3 dir = new Vector3(node.position.x - currentNode.position.x, 0, node.position.z - currentNode.position.z);
        characterTransform.rotation = Quaternion.LookRotation(dir);
    }

    public void faceCharacter(Transform currentNode, Enums.Direction direction)
    {
        Vector3 dir = currentNode.position;
        switch (direction)
        {
            case Enums.Direction.UP:
                dir += new Vector3(5, 0, 0);
                break;
            case Enums.Direction.DOWN:
                dir += new Vector3(-5, 0, 0);
                break;
            case Enums.Direction.LEFT:
                dir += new Vector3(0, 0, 5);
                break;
            case Enums.Direction.RIGHT:
                dir += new Vector3(0, 0, -5);
                break;
            default:
                throw new System.Exception("This should never happen!");
        }
        Vector3 rotation = new Vector3(dir.x - currentNode.position.x, 0, dir.z - currentNode.position.z);
        characterTransform.rotation = Quaternion.LookRotation(rotation);
    }

    public void moveCharacter(Transform currentNode, Transform node)
    {
        this.currentNode = currentNode;
        goalNode = node;
        nextPosition = node.position;

        setState(currentNode, node);

        switch (characterState)
        {            
            case CharacterState.WALKING:
                transporter.move(currentNode.position, node.position,step1,step2);
                break;

            case CharacterState.START_CLIMBING_UP:
                SoundManager.instance.playMarioEffect(startClimbing);
                break;

            case CharacterState.STOP_CLIMBING_UP:
                SoundManager.instance.playMarioEffect(stopClimbing);
                break;

            case CharacterState.START_CLIMBING_DOWN:
                SoundManager.instance.playMarioEffect(startClimbing);
                break;

            case CharacterState.STOP_CLIMBING_DOWN:
                SoundManager.instance.playMarioEffect(stopClimbing);
                break;

            case CharacterState.CLIMBING_UP:
                {
                    Vector3 difference = node.position - currentNode.position;
                    transporter.move(characterTransform.position, characterTransform.position + difference);
                    SoundManager.instance.playMarioEffect(climbing);
                    break;
                }
            case CharacterState.CLIMBING_DOWN:
                {
                    Vector3 difference = node.position - currentNode.position;
                    transporter.move(characterTransform.position, characterTransform.position + difference);
                    SoundManager.instance.playMarioEffect(climbing);
                    break;
                }
            case CharacterState.CLIMBING_SIDE:
                {
                    Vector3 difference = node.position - currentNode.position;
                    transporter.move(characterTransform.position, characterTransform.position + difference);
                    SoundManager.instance.playMarioEffect(climbing);
                    break;

                }
        }

        if (characterState != CharacterState.CLIMBING_SIDE) faceCharacter(currentNode, node);

    }

    private void setPlayerPosition()
    {
        switch (characterState)
        {
            case CharacterState.CLIMBING_IDLE:
                setCharacterPosition(goalNode.position - new Vector3(0, 2.5f, 1));
                break;
            case CharacterState.STOP_CLIMBING_DOWN:
                setCharacterPosition(goalNode.position);
                break;
            case CharacterState.STOP_CLIMBING_UP:
                setCharacterPosition(currentNode.position + new Vector3(0,-1,0));
                break;
            case CharacterState.START_CLIMBING_DOWN:
                setCharacterPosition(currentNode.position + new Vector3(-0.75f, -4, -2.5f));
                break;
        }
    }

    private void setState(Transform currentNode, Transform node)
    {
        int heightDifference = (int)Mathf.Round(node.position.y - currentNode.position.y);
        int depthDifference = (int)Mathf.Round(node.position.z - currentNode.position.z);
        int widthDifference = (int)Mathf.Round(node.position.x - currentNode.position.x);

        switch (characterState)
        {
            case CharacterState.IDLE:

                if (heightDifference == 0)
                {
                    characterState = CharacterState.WALKING;
                    anim.SetBool("walking", true);
                }
                else if (heightDifference > 0)
                {
                    characterState = CharacterState.START_CLIMBING_UP;
                    anim.SetBool("startClimbingUp", true);
                }
                else
                {
                    characterState = CharacterState.START_CLIMBING_DOWN;
                    anim.SetBool("startClimbingDown", true);
                }

                break;
                
            case CharacterState.CLIMBING_IDLE:
                if (heightDifference == 0 && (widthDifference != 0 || depthDifference != 0))
                {
                    characterState = CharacterState.CLIMBING_SIDE;
                    anim.SetBool("climbSide", true);
                    anim.SetBool("idleHanging", false);
                }
                else if (heightDifference > 0)
                {
                    if (widthDifference != 0 || depthDifference != 0)
                    {
                        characterState = CharacterState.STOP_CLIMBING_UP;
                        anim.SetBool("endClimbingUp", true);
                        anim.SetBool("idleHanging", false);
                    }
                    else
                    {
                        characterState = CharacterState.CLIMBING_UP;
                        anim.SetBool("climbUp", true);
                        anim.SetBool("idleHanging", false);
                    }
                    
                }
                else if (heightDifference < 0)
                {
                    if (widthDifference != 0 || depthDifference != 0)
                    {
                        characterState = CharacterState.STOP_CLIMBING_DOWN;
                        anim.SetBool("endClimbingDown", true);
                        anim.SetBool("idleHanging", false);
                    }
                    else
                    {
                        characterState = CharacterState.CLIMBING_DOWN;
                        anim.SetBool("climbDown", true);
                        anim.SetBool("idleHanging", false);
                    }

                }
                break;
            
        }
    }

    public void moveFeint()
    {
        characterState = CharacterState.DEFAETED;
        SoundManager.instance.playMarioEffect(defeated);
        anim.SetBool("defeated", true);
    }

    public void jump()
    {
        characterState = CharacterState.JUMPING;
        anim.SetBool("jump", true);
        SoundManager.instance.playMusicEffect(jumpSound);
        SoundManager.instance.playMarioEffect(getRandomClip(jumpMario));
    }


    public void giveFire()
    {
        character.getFirePower();
    }

    public void shootFireBall()
    {
        if (character.isOnFire() && characterState == CharacterState.IDLE)
        {
            characterState = CharacterState.SHOT_FIREBALL;
            anim.SetBool("shotFireball", true);
            Vector3 fireOrigin = transform.position + Vector3.up*1.5f;
            Fire.instance.shoot(fireOrigin, transform.forward);
            SoundManager.instance.playMusicEffect(shoot);
        }

    }

    public void retrieveFirePower()
    {
        character.retrieveFirePower();
    }

    public void kill()
    {
        if (characterState != CharacterState.DYING)
        {
            characterState = CharacterState.DYING;
            transporter.stop();
            anim.Play("Die");
            SoundManager.instance.playMarioEffect(getRandomClip(dying));
            SoundManager.instance.playDefeatMusic();
        }
    }

    public void pauseAnimation()
    {
        currentAnimationSpeed = anim.speed;
        anim.speed = 0;
    }

    public void resumeAnimation()
    {
        anim.speed = currentAnimationSpeed;
    }

    public void sayRandomThing()
    {
        SoundManager.instance.playMarioEffect(getRandomClip(random));
    }

    public Vector3 getCharacterPosition()
    {
        return characterTransform.position;
    }

    public Vector3 getCharacterNextPosition()
    {
        return nextPosition;
    }

    public void celebrateVictory()
    {
        win = true;
    }

    /******************* Animations Events *******************/

    public void EndAnimationStopClimbingUp()
    {
        setCharacterPosition(goalNode.position);
        characterState = CharacterState.IDLE;
        anim.SetBool("endClimbingUp", false);
    }

    public void EndAnimationStartClimbingUp()
    { 
        characterState = CharacterState.CLIMBING_IDLE;
        anim.SetBool("startClimbingUp", false);
        anim.SetBool("idleHanging", true);

    }

    public void EndAnimationStartClimbingDown()
    {
        characterState = CharacterState.CLIMBING_IDLE;
        characterTransform.rotation = Quaternion.LookRotation(Vector3.forward);
        anim.SetBool("startClimbingDown", false);
        anim.SetBool("idleHanging", true);

    }

    public void EndAnimationStopClimbingDown()
    {
        characterState = CharacterState.IDLE;
        anim.SetBool("endClimbingDown", false);
    }

    public void EndAnimationDefeated()
    {
        characterState = CharacterState.IDLE;
        anim.SetBool("defeated", false);
    }

    public void EndJumpingAnimation()
    {
        characterState = CharacterState.IDLE;
        anim.SetBool("jump", false);
    }

    public void EndShootAnimation()
    {
        characterState = CharacterState.IDLE;
        anim.SetBool("shotFireball", false);
    }

    public void EndDyingAnimation()
    {
        characterState = CharacterState.IDLE;
        GameManager.instance.resetLevel();
    }

    public bool isIdle()
    {
        return characterState == CharacterState.IDLE;
    }

    public bool ready()
    {
        return characterState == CharacterState.IDLE || characterState == CharacterState.CLIMBING_IDLE || characterState == CharacterState.WINNING;
    }

    private AudioClip getRandomClip(List<AudioClip> list)
    {
        int max = list.Count;
        int index = Random.Range(0, max);
        return list[index];
    }
}
