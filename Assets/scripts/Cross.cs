using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cross : MonoBehaviour {

    public List<Sprite> arrowCross;
    public List<Sprite> letterCross;

    private float currentTime;
    private Image[] images;
    private bool selected;

    // Use this for initialization
    void Start () {
        images = GetComponentsInChildren<Image>();
        currentTime = 0;
        selected = true;
        setCross(arrowCross);
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if (currentTime >= 1)
        {
            selected = !selected;
            currentTime = 0;
            if (selected)
            {
                setCross(arrowCross);
            }
            else
            {
                setCross(letterCross);
            }

        }
	}

    private void setCross(List<Sprite> text)
    {
        for (int i = 0; i < images.Length; ++i)
        {
            images[i].overrideSprite = text[i];
        }
    }
}
