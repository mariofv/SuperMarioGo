using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public List<GameObject> possibleNodes;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver() {
        if (Input.GetMouseButtonUp(0)) {
            GameManager.instance.handleAction(new NodeClickAction(gameObject));
        }
    }

    public bool isAccesibleNode(GameObject node)
    {
        return possibleNodes.Contains(node);
    }

}
