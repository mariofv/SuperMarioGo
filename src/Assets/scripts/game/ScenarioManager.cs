using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour {

    public static ScenarioManager instance = null;
    
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

    public List<MobileBlock> mobileBlocks;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    public void moveAllBlocks()
    {
        foreach (MobileBlock b in mobileBlocks)
        {
            b.moveblocks();
        }
    }

    public bool ready()
    {
        foreach (MobileBlock b in mobileBlocks)
        {
            if (!b.ready())
            {
                return false;
            }
            
        }
        return true;
    }
}
