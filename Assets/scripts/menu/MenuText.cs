using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuText : MonoBehaviour {

    Animator animator;
    string nextText;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        
    }

    public void setText(string text)
    {
        GetComponent<Text>().text = text;
    }


    public void stopSwapText()
    {
        animator.SetBool("swap", false);
    }

    public void swapText(string text)
    {
        nextText = text;
        animator.SetBool("swap", true);
    }

    public bool swaping()
    {
        return animator.GetBool("swap");
    }

    private void setNextText()
    {
        GetComponent<Text>().text = nextText;
    }
}
