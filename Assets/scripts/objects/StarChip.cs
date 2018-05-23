using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarChip : MonoBehaviour {

    List<Texture> textures;

	// Use this for initialization
	void Start () {
        textures = new List<Texture>();
        textures.Add(Resources.Load("textures\\benv") as Texture);
        textures.Add(Resources.Load("textures\\yenv") as Texture);

        Random.InitState((int)System.DateTime.Now.Ticks);
        int currentTexture = Random.Range(0, 2);
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_SPECGLOSSMAP");

        gameObject.GetComponent<Renderer>().material.SetTexture("_SpecGlossMap",textures[currentTexture]);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
