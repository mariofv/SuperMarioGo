using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPressedAction : Action {

    private GameObject node;
    private GameObject currentNode;
    private Node nodeScript;

    private Enums.Direction direction;

    public DirectionPressedAction(Enums.Direction direction)
    {
        currentNode = GameManager.instance.getCurrentNode();
        nodeScript = currentNode.GetComponent<Node>();
        this.direction = direction;

        node = nodeScript.getAdjacentNode(direction);
        
    }

    public override void execute()
    {
        if (node != null && node.transform.parent.parent.gameObject.activeSelf)
        {
            CharacterManager.instance.moveCharacter(currentNode.transform.parent, node.transform.parent);
            GameManager.instance.setCurrentNode(node);
        }
        else
        {
            if (CharacterManager.instance.isIdle())
            {
                CharacterManager.instance.faceCharacter(currentNode.transform.parent, direction);
                CharacterManager.instance.moveFeint();
            }
        }
    }

    public override bool triggersIteration()
    {
        return node != null && node.transform.parent.parent.gameObject.activeSelf;
    }
}
