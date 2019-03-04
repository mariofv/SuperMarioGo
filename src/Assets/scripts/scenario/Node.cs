using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    private Dictionary<Enums.Direction, GameObject> possibleNodes;

    public GameObject nodeUP;
    public GameObject nodeDOWN;
    public GameObject nodeLEFT;
    public GameObject nodeRIGHT;

    // Use this for initialization
    void Start () {
        possibleNodes = new Dictionary<Enums.Direction, GameObject>();
        possibleNodes.Add(Enums.Direction.UP, nodeUP);
        possibleNodes.Add(Enums.Direction.DOWN, nodeDOWN);
        possibleNodes.Add(Enums.Direction.LEFT, nodeLEFT);
        possibleNodes.Add(Enums.Direction.RIGHT, nodeRIGHT);
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
        Debug.Log(node.transform.parent.parent.gameObject.name + " " + node.transform.parent.parent.gameObject.activeSelf);

        return possibleNodes.ContainsValue(node) && node.transform.parent.parent.gameObject.activeSelf;
    }

    public GameObject getAdjacentNode(Enums.Direction direction)
    {
        return possibleNodes[direction];
    }

}
