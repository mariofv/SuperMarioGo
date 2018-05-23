using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public float speed;
    public float initY, goalY;

    private bool ascending, descending;
    private float currentProgress;
    private Vector3 iniPos, goalPos;
    private RectTransform transforma;

	// Use this for initialization
	void Start () {
        ascending = false;
        descending = false;

        iniPos = new Vector3(0, initY, 0);
        goalPos = new Vector3(0, goalY, 0);

        currentProgress = 0;

        transforma = GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {

        if (ascending)
        {
            currentProgress += speed * Time.deltaTime;
            float step = currentProgress/ Mathf.Abs(goalY- initY);
            transforma.localPosition = Vector3.Lerp(goalPos, iniPos, step);

            if (Vector3.Distance(transforma.localPosition, iniPos) == 0)
            {
                currentProgress = 0;
                ascending = false;

            }
        }
        if (descending)
        {
            currentProgress += speed * Time.deltaTime;
            float step = currentProgress / Mathf.Abs(goalY - initY);
            transforma.localPosition = Vector3.Lerp(iniPos, goalPos, step);

            if (Vector3.Distance(transforma.localPosition, goalPos) == 0)
            {
                currentProgress = 0;
                descending = false;
            }
        }
        
	}

    public void ascend()
    {
        ascending = true;
    }

    public void descend()
    {
        descending = true;
    }

    public bool ready()
    {
        return !ascending && !descending;
    }
}
