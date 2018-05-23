using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour {

    public float speed;

    private int currentPos;
    private int lastPos;

    private bool moving;
    private float currentProgress;

    private List<float> positions;

    // Use this for initialization
    void Start()
    {
        currentPos = 0;
        currentProgress = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            currentProgress += speed * Time.deltaTime;
            float step = currentProgress / Mathf.Abs(positions[lastPos] - positions[currentPos]);
            float xPos = Mathf.Lerp(positions[lastPos], positions[currentPos], step);
            transform.localPosition -= new Vector3(transform.localPosition.x + xPos, 0, 0);
            if (xPos == positions[currentPos])
            {
                moving = false;
                currentProgress = 0;
            }
        }
    }

    public void moveRight()
    {
        if (currentPos + 1 != positions.Count)
        {
            lastPos = currentPos++;
            moving = true;
        }
    }

    public void moveLeft()
    {
        if (currentPos - 1 != -1)
        {
            lastPos = currentPos--;
            moving = true;
        }
        
    }

    public void setPositions(List<float> positions)
    {
        this.positions = positions;
    }

    public bool ready()
    {
        return !moving;
    }
}
