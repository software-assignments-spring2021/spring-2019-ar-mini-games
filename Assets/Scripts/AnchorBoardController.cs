using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorBoardController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject thing;
    bool once;
    // Use this for initialization
    void Start()
    {
        gameObject.transform.rotation = new Quaternion(-90f, 0, 0, 0);
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("AnchorBoard") != null && !once)
        {
            Debug.Log("foiund anchor");
            thing = GameObject.FindWithTag("AnchorBoard");
            thing.transform.rotation = new Quaternion(
                -90f, 0f, 0f, 0.5f
);


            once = true;
        }

    }
}
