using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float transformingSpeed;
    public AudioClip powerUp;
    public AudioClip powerDown;

    private SkinnedMeshRenderer meshRenderer;

    private Material normalMatA;
    private Material normalMatB;
    private Material fireMatA;
    private Material fireMatB;

    private bool transforming;
    private bool fire;

    private int countTransitions;
    private int numTransitions;

    private float timeSinceLastCall;

    // Use this for initialization
    void Start () {
        initMaterials();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        transforming = false;

        numTransitions = 6;
    }
	
	// Update is called once per frame
	void Update () {
		if (transforming)
        {
            timeSinceLastCall += Time.deltaTime;
            if (timeSinceLastCall > 10/ transformingSpeed)
            {
                timeSinceLastCall = 0;
                ++countTransitions;
                fire = !fire;
                if (fire)
                {
                    setFireMario();
                }
                else
                {
                    setNormalMario();
                }
            }

            if (countTransitions == numTransitions)
            {
                transforming = false;
            }


        }
	}

    public void getFirePower()
    {
        fire = true;
        transformation();
        SoundManager.instance.playMusicEffect(powerUp);
    }

    public void retrieveFirePower()
    {
        fire = false;
        transformation();
        SoundManager.instance.playMusicEffect(powerDown);
    }

    private void transformation()
    {
        transforming = true;
        countTransitions = 0;
        timeSinceLastCall = 0 ;
    }

    private void setNormalMario()
    {
        Material[] materials = meshRenderer.sharedMaterials;
        materials[0] = normalMatA;
        materials[1] = normalMatB;
        meshRenderer.sharedMaterials = materials;
    }

    private void setFireMario()
    {
        Material[] materials = meshRenderer.sharedMaterials;
        materials[0] = fireMatA;
        materials[1] = fireMatB;
        meshRenderer.sharedMaterials = materials;
    }

    private void initMaterials()
    {
        normalMatA = Resources.Load("prefabs/characters/Mario/body_a") as Material;
        normalMatB = Resources.Load("prefabs/characters/Mario/body_b") as Material;
        fireMatA = Resources.Load("prefabs/characters/Mario/body_a_fire") as Material;
        fireMatB = Resources.Load("prefabs/characters/Mario/body_b_fire") as Material;
    }

    public bool ready()
    {
        return !transforming;
    }

    public bool isOnFire()
    {
        return fire && !transforming;
    }
}
