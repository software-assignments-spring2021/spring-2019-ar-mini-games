using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScoring : MonoBehaviour
{
    // Start is called before the first frame update
    ArrayList myList;

    string collisionTag;
    void Start()
    {
        myList = new ArrayList();
    }

    // Update is called once per frame
    void register(string board){
        
    }

    void OnCollisionEnter(Collision collision)
    {
        collisionTag = collision.gameObject.tag;
        myList.Add(collisionTag);
        Debug.Log(myList);

    }


}

