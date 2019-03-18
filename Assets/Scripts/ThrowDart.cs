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
            rb.AddForce(transform.forward * thrust);
        }





    }


    // detect objects the dart collides with
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "DartBoard")
        {
            Debug.Log("Hit DartBoard!");

            // make dart "stick" to board by turning off gravity, movement, rotation
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.freezeRotation = true;

            Invoke("DestroyDart", 2);

        } // end of if dartboard

    }


    void DestroyDart()
    {
        Instantiate(this.gameObject, new Vector3(0, 0.25f, -4f), Quaternion.identity);
        Destroy(this.gameObject);


    }

}