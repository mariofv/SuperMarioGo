using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollView : MonoBehaviour {

    public List<GameObject> scrollContents;

    private List<Vector3> scrollPositions;
    private int currentPosition;
    private Transporter transporter;

	// Use this for initialization
	void Start () {

        scrollPositions = new List<Vector3>();
	    for (int i = 0; i < scrollContents.Count; ++i)
        {
            scrollPositions.Add(scrollContents[i].transform.localPosition);
        }

        currentPosition = 0;
        transporter = GetComponent<Transporter>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool canMoveLeft()
    {
        return currentPosition - 1 != -1;
    }

    public bool canMoveRight()
    {
        return currentPosition + 1 != scrollPositions.Count;
    }

    public void moveLeft()
    {
        transporter.move(scrollPositions[currentPosition], scrollPositions[currentPosition-1]);
        --currentPosition;
    }

    public void moveRight()
    {
        transporter.move(scrollPositions[currentPosition], scrollPositions[currentPosition + 1]);
        ++currentPosition; 
    }

    public bool ready()
    {
        return !transporter.isMoving();
    }
}
