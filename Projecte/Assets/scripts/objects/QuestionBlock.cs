using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : SpecialBlock {

    public AudioClip flowerRising;

    private GameObject usedBlock;
    private GameObject questionBlock;
    private GameObject flower;

    private Vector3 topFlowerPosition;
    private Transporter flowerTransporter;

    private float countTime;

    private bool active;
    private bool givingFire;

	// Use this for initialization
	void Start () {
        usedBlock = transform.GetChild(0).gameObject;
        questionBlock = transform.GetChild(1).gameObject;
        flower = transform.GetChild(2).gameObject;
        flowerTransporter = GetComponentInChildren<Transporter>();
        topFlowerPosition = flower.transform.position + Vector3.up * 2.32f;
        active = true;
        givingFire = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (flower.activeSelf && flower.transform.position == topFlowerPosition)
        {
            countTime += Time.deltaTime;
            if (countTime >= 1)
            {
                flower.SetActive(false);
                CharacterManager.instance.giveFire();
                givingFire = false;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (active && other.gameObject.name == "body_set_L")
        {
            activateBlock();
        }
    }
    
    public void activateBlock()
    {
        GetComponent<Animator>().SetBool("activate", true);
        active = false;
    }

    public void riseFlower()
    {
        SoundManager.instance.playMusicEffect(flowerRising);
        GetComponent<Animator>().SetBool("activate", false);
        usedBlock.SetActive(true);
        questionBlock.SetActive(false);
        flowerTransporter.move(flower.transform.position, topFlowerPosition);
        countTime = 0;
        givingFire = true;
    }

    public bool isActive()
    {
        return active;
    }

    public override bool ready()
    {
        return !flowerTransporter.isMoving() && !GetComponent<Animator>().GetBool("activate") && !givingFire;

    }
}
