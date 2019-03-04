using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public AudioClip enemyHit;
    public List<GameObject> node;

    private Animator anim;
    private EnemyState state;
    private Transform enemyTransform;
    private Transporter transporter;
    private int currentIndex;
    private bool hasToMove;
    private bool alive;
    private bool forward;

    enum EnemyState
    {
        IDLE,
        DYING,
        WALKING
    };

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        enemyTransform = GetComponent<Transform>();
        transporter = GetComponent<Transporter>();
        alive = true;
        forward = true;
        currentIndex = 0;
        state = EnemyState.IDLE;
    }
	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case EnemyState.IDLE:
                break;

            case EnemyState.WALKING:
                if (!transporter.isMoving())
                {
                    state = EnemyState.IDLE;
                    anim.SetBool("Walking", false);
                }
                break;
        }
    }

    public void moveEnemy()
    {
        if (node.Count == 0)
        {
            return;
        }

        anim.SetBool("Walking", true);
        state = EnemyState.WALKING;
        int nextIndex = 0;

        if (forward)
        {
            nextIndex = currentIndex + 1;
            if (nextIndex == node.Count)
            {
                nextIndex = currentIndex - 1;
                forward = false;
            }
        }
        
        else
        {
            nextIndex = currentIndex - 1;
            if (currentIndex == 0)
            {
                nextIndex = currentIndex + 1;
                forward = true;
            }
            
        }

        Transform currentNode = node[currentIndex].transform;
        Transform nextNode = node[nextIndex].transform;
        faceEnemy(currentNode, nextNode);
        transporter.move(currentNode.position, nextNode.position);
        currentIndex = nextIndex;
    }

    private void faceEnemy(Transform currentNode, Transform node)
    {
        Vector3 dir = new Vector3(node.position.x - currentNode.position.x, 0, node.position.z - currentNode.position.z);
        transform.rotation = Quaternion.LookRotation(dir);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "body_set_L")
        {
            CharacterManager.instance.kill();
        }
    }

    public bool ready()
    {
        return !transporter.isMoving();
    }

    public void kill()
    {
        alive = false;
        SoundManager.instance.playMusicEffect(enemyHit);
        Vector3 deathCloudPos = transform.position + Vector3.up * 2;
        DeathCloud.instance.activate(deathCloudPos);
        gameObject.SetActive(false);
    }

    public bool isAlive()
    {
        return alive;
    }
}