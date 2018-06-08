using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlockManager : MonoBehaviour {
    public static SpecialBlockManager instance = null;
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

    public List<SpecialBlock> specialBlocks;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool allSpecialBlocksReady()
    {
        foreach (SpecialBlock s in specialBlocks)
        {
            if (!s.ready())
            {
                return false;
            }
        }
        return true;
    }

    public void enterPipe(GameObject node)
    {
        foreach (SpecialBlock s in specialBlocks)
        {
            if (s.GetType() == typeof(TransportPipe))
            {
                ((TransportPipe)s).enter(node);
            }
        }
    }
}
