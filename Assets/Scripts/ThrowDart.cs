using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDart : MonoBehaviour
{
    private Rigidbody rb;
    public int thrust;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("pressed");
            rb.useGravity = true;
            rb.AddForce(transform.forward * thrust);
            Invoke("DestroyDart", 3);
        }





    }


    // detect objects the dart collides with
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "DartBoard")
        {   
            rb.velocity = Vector3.zero;

            Debug.Log("Hit DartBoard!");

            // make dart "stick" to board by turning off gravity, movement, rotation
            rb.useGravity = false;
            rb.freezeRotation = true;

            //Invoke("DestroyDart", 2);

        } // end of if dartboard



    }


    void DestroyDart()
    {

        Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f,0.8f)); 
       
        GameObject dartCpy = Instantiate(this.gameObject, p, Camera.main.transform.rotation);
        dartCpy.transform.parent = GameObject.FindWithTag("MainCamera").transform;

        Destroy(this.gameObject);


    }

}