using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour {

    private string sceneFilePath;
    private bool[,] scenearioMatrix;
    private GameObject[,] scenearioObjectMatrix;
    
	// Use this for initialization
	void Start () {
        scenearioMatrix = new bool[10, 10];
        scenearioObjectMatrix = new GameObject[10, 10];

        for (int i = 0; i < 10; ++i)
        {
            for (int j = 0; j < 10; ++j)
            {
                scenearioObjectMatrix[i, j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                scenearioObjectMatrix[i, j].transform.parent = gameObject.transform;
                scenearioObjectMatrix[i, j].transform.position = new Vector3(i, 0, j);

                if ((i + j)%2 == 0)
                {
                    scenearioObjectMatrix[i, j].SetActive(false);
                }
            }
        }

    }

    // Update is called once per frame
    void Update () {
		
	}

}
