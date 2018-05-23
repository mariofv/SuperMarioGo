using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuText : MonoBehaviour {

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
        animator.SetBool("swapLeft", false);
        animator.SetBool("swapRight", false);

    }

    public void swapText(string text, bool right)
    {
        nextText = text;
        if (right)
        {
            animator.SetBool("swapRight", true);
        }
        else
        {
            animator.SetBool("swapLeft", true);
        }
    }

    public bool swaping()
    {
        return animator.GetBool("swapRight") || animator.GetBool("swapLeft");
    }

    public void enable()
    {
        GetComponent<Text>().enabled = true;
    }

    public void disable()
    {
        GetComponent<Text>().enabled = false;
    }

    private void setNextText()
    {
        GetComponent<Text>().text = nextText;
    }
}
