using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeClickAction : Action {

    private GameObject node;
    private GameObject currentNode;

    public NodeClickAction(GameObject node)
    {
        this.node = node;
        currentNode = GameManager.instance.getCurrentNode();
    }

    public override void execute()
    {
        Node nodeScript = currentNode.GetComponent<Node>();
        if (nodeScript.isAccesibleNode(node))
        {
            CharacterManager.instance.moveCharacter(currentNode.transform.parent, node.transform.parent);
            GameManager.instance.setCurrentNode(node);
        }
    }

    public override bool triggersIteration()
    {
        return true;
    }
}
