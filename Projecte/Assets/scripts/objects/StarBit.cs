using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBit : MonoBehaviour {
    
    private List<Color> colors;

	// Use this for initialization
	void Start () {
        colors = new List<Color>();
        colors.Add(Color.blue);
        colors.Add(Color.red);
        colors.Add(new Color(191f / 255, 186f / 255, 0));

        Random.InitState((int)System.DateTime.Now.Ticks);
        int currentColor = Random.Range(0, 3);
        

        gameObject.GetComponent<Renderer>().material.color = colors[currentColor];
    }

    // Update is called once per frame
    void Update()
    {
    }
}
