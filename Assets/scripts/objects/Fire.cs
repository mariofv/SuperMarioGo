using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public static Fire instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public float speedHorizontal;
    public float speedVertical;
    public float height;

    public Vector3 hiddenPosition;
    private Vector3 direction;
    private bool moving;
    private float originalY;

	// Use this for initialization
	void Start () {
        hide();
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            transform.position += direction * speedHorizontal * Time.deltaTime;
            float y = originalY + Mathf.Sin(Time.fixedTime * speedVertical) * height;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
	}

    public void shoot(Vector3 origin, Vector3 direction)
    {
        transform.position = origin;
        originalY = origin.y;
        this.direction = direction;
        moving = true;
    }

    public bool ready()
    {
        return !moving;
    }

    private void hide()
    {
        transform.position = hiddenPosition;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "World Bounding Box")
        {
            destroyFire();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().kill();
            destroyFire();
        }
    }

    private void destroyFire()
    {
        CharacterManager.instance.retrieveFirePower();
        moving = false;
        hide();
    }
}
