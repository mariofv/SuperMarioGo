using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScroller : MonoBehaviour {

    public float speed;
    public float initY, goalY;

    private bool descending;
    private float currentProgress;
    private Vector3 iniPos, goalPos;
    private RectTransform transforma;

    private void OnDisable()
    {
        currentProgress = 0;
    }

    // Use this for initialization
    void Start()
    {
        descending = true;
        iniPos = new Vector3(0, initY, 0);
        goalPos = new Vector3(0, goalY, 0);

        currentProgress = 0;

        transforma = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
