using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject menuButtons;
    public Text buttonText;
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
        rotate();
	}

    
    void Update()
    {
        if (rotating)
        {
            float step = speed * Time.deltaTime;
            menuButtons.transform.rotation = Quaternion.Slerp(menuButtons.transform.rotation, rotations[currentRotation], step);

            if (Quaternion.Angle(menuButtons.transform.rotation, rotations[currentRotation]) == 0)
            {
                menuButtons.transform.rotation = rotations[currentRotation];
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
        string buttonName = menuButtons.GetComponentsInChildren<MenuButton>()[currentRotation].buttonName;
        buttonText.text = buttonName;
    }
}
