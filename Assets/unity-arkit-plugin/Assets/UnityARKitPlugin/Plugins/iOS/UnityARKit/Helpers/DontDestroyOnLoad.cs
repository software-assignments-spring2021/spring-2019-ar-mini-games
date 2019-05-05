using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroyOnLoad : MonoBehaviour {
    GameObject thing;
    bool once;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad (gameObject);
        gameObject.transform.rotation = new Quaternion(90f, 0f, 0, 0);
        once = false;
	}
	
    void Update()
    {
        if (GameObject.FindWithTag("AnchorBoard") != null && !once)
        {
            Debug.Log("foiund anchor");
            thing = GameObject.FindWithTag("AnchorBoard");
            thing.transform.rotation = new Quaternion(
                90f, 0, 0f, 0.5f
);

            once = true;
        }

    }
}
