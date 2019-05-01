using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovementController : MonoBehaviour
{
    int isHit = -1;
    float x;
    float y;
    float z;
    float timeCounter = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dart")
        {

            Debug.Log("tag inner board");
            isHit = isHit * -1;


        }
    }


    // Update is called once per frame
    void Update()
    {
        // for game testing only
        //if (Input.GetMouseButtonUp(0))
        //{
        //    isHit = isHit * -1;
        //    Debug.Log("yo " + isHit);
        //}
        // end of for game testing only

        if (isHit == 1)
        {
            timeCounter += Time.deltaTime;
        }
        else{
            timeCounter -= Time.deltaTime;
        }
        x = Mathf.Cos(timeCounter);
        y = Mathf.Sin(timeCounter);
        z = 5;
        transform.position = new Vector3(x, y, z);

    }
        

}
