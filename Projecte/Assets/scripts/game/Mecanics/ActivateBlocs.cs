using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBlocs : MonoBehaviour {

    private Transform activationPanels;
    public GameObject activatingNode;
    public List<GameObject> Bloc;
    public AudioClip activate;
    bool pressed = false;
    
	// Use this for initialization
	void Start () {
        activationPanels = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!pressed && CharacterManager.instance.getCharacterPosition() == activatingNode.transform.position)
        {
            if (activationPanels.GetChild(0).gameObject.activeSelf)
            {
                activationPanels.GetChild(0).gameObject.SetActive(false);
                activationPanels.GetChild(1).gameObject.SetActive(true);
                SoundManager.instance.playMusicEffect(activate);

                for (int i = 0; i < Bloc.Count; ++i)
                {
                    Bloc[i].SetActive(true);
                }

            }

            else 
            {
                activationPanels.GetChild(0).gameObject.SetActive(true);
                activationPanels.GetChild(1).gameObject.SetActive(false);
                SoundManager.instance.playMusicEffect(activate);

                for (int i = 0; i < Bloc.Count; ++i)
                {
                    Bloc[i].SetActive(false);
                }
            }
            pressed = true;
        }

        if (CharacterManager.instance.getCharacterPosition() != activatingNode.transform.position)
        {
            pressed = false;
        }

	}

}
