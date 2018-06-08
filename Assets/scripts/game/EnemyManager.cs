using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public List<Enemy> enemies;
    public static EnemyManager instance = null;

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

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void moveEnemies()
    {
        foreach (Enemy e in enemies)
        {
            if (e.isAlive())
            {
                e.moveEnemy();
            }
        }
    }

    public bool allEnemiesReady()
    {
        foreach (Enemy e in enemies)
        {
            if (!e.ready())
            {
                return false;
            }
        }
        return true;
    }
}
