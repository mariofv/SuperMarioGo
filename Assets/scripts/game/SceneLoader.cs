using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public static SceneLoader instance = null;

    //Awake is always called before any Start functions
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

    public GameObject canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void reloadScene()
    {
        deactivateAllObjects();
        canvas.SetActive(true);
        StartCoroutine(loadSceneAsync(SceneManager.GetActiveScene().name));
    }

    public void loadScene(string sceneName)
    {
        deactivateAllObjects();
        canvas.SetActive(true);
        StartCoroutine(loadSceneAsync(sceneName));
    }

    IEnumerator loadSceneAsync(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            yield return null;
        }
        canvas.SetActive(false);
    }

    private void deactivateAllObjects()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject a in allObjects)
        {
            if (a != gameObject && a.name != "Main Camera")
            {
                a.SetActive(false);
            }       
        }

    }
}
