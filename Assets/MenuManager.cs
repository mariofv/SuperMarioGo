using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public Transform cameraTargetTransform;
    public float speed;
    public MenuButton actualMenuPoint;

    private Quaternion targetRotationTransform;
    private bool rotate;

    // Use this for initialization
    void Start () {
        targetRotationTransform = new Quaternion();

        rotate = false;
	}

    
    void Update()
    {
        if (!rotate)
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                targetRotationTransform.SetFromToRotation(actualMenuPoint.transform.position, actualMenuPoint.leftPoint.position);
                rotate = true;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                targetRotationTransform.SetFromToRotation(actualMenuPoint.transform.position, actualMenuPoint.rightPoint.position);
                rotate = true;

            }
        }
        
        else
        {
            float step = speed * Time.deltaTime;
            cameraTargetTransform.rotation = Quaternion.Slerp(cameraTargetTransform.rotation, targetRotationTransform, step);
            Debug.Log(Quaternion.Slerp(cameraTargetTransform.rotation, targetRotationTransform, step));
            
        }
        

        
    }
}
