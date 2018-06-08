using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonRulette : MonoBehaviour {

    public float speed;

    private List<Quaternion> rotations;

    private int currentRotation;
    private bool rotating;

    // Use this for initialization
    void Start () {
        rotations = new List<Quaternion>();
        rotations.Add(Quaternion.AngleAxis(0, Vector3.up));
        rotations.Add(Quaternion.AngleAxis(90, Vector3.up));
        rotations.Add(Quaternion.AngleAxis(180, Vector3.up));
        rotations.Add(Quaternion.AngleAxis(270, Vector3.up));

        currentRotation = 0;
        rotating = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (rotating)
        {
            float step = speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotations[currentRotation], step);
            if (Quaternion.Angle(transform.rotation, rotations[currentRotation]) == 0)
            {
                transform.rotation = rotations[currentRotation];
                rotating = false;
            }
        }
    }

    public void rotateLeft()
    {
        if (--currentRotation == -1)
        {
            currentRotation = 3;
        }
        rotate();
    }

    public void rotateRight()
    {
        if (++currentRotation == 4)
        {
            currentRotation = 0;
        }
        rotate();
    }

    private void rotate()
    {
        rotating = true;
    }

    public string getCurrentButtonName()
    {
        return GetComponentsInChildren<MenuMainButton>()[currentRotation].buttonName;
    }

    public bool isRotating()
    {
        return rotating;
    }

    public Menu getCurrentButtonSubMenu()
    {
        return GetComponentsInChildren<MenuMainButton>()[currentRotation].subMenu;
    }
    
}
