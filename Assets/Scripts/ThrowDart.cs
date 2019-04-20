using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDart : MonoBehaviour
{
    private Rigidbody rb;
    public int thrust;
    public int dartCounter;
    public bool gameOver = false; 

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // click screen to throw dart
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            {
                Debug.Log("pressed");
                rb.useGravity = true;
                rb.AddForce(transform.forward * thrust);
                this.gameObject.transform.parent = null;
                Invoke("DestroyDart", 3);
            }
        }
    }
    
    // detect objects the dart collides with
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "DartBoard")
        {
            // Turn off collider and stop dart
            gameObject.GetComponent<BoxCollider>().enabled = false;
            rb.velocity = Vector3.zero;
            // make dart "stick" to board by turning off gravity, movement, rotation
            rb.useGravity = false;
            rb.freezeRotation = true;
        } // end of if dartboard
    }

    void DestroyDart()
    {
        updateDartCounter();
        Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.45f,0.8f)); 
       
        GameObject dartCpy = Instantiate(this.gameObject, p, Camera.main.transform.rotation);
        dartCpy.transform.parent = GameObject.FindWithTag("MainCamera").transform;
        dartCpy.GetComponent<BoxCollider>().enabled = true;
        Destroy(this.gameObject);
    }

    public void updateDartCounter(){
        var dartCounterObject = GameObject.Find("DartManager");
        var dartCountScript = dartCounterObject.GetComponent<DartCounter>();
        dartCountScript.dartCounter -= 1;

        if (dartCountScript.dartCounter <= 0){
            gameOver = true; 
        }
    }

    public int getDartCounter(){
        var dartCounterObject = GameObject.Find("DartManager");
        var dartCountScript = dartCounterObject.GetComponent<DartCounter>();
        return dartCountScript.dartCounter;
    }
}