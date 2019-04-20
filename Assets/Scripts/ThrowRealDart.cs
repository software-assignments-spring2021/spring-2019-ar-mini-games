using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowRealDart : MonoBehaviour
{
    private Rigidbody rb;
    public int thrust;
    public bool gameOver = false;
    public GameObject dart;
    bool fired = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // Check that the screen is pressed and we are not currently firing:
        if (Input.GetMouseButtonDown(0) && !fired)
        {
            // Shortcircuit to check for adjusting the board??
            if (EventSystem.current.IsPointerOverGameObject() ||
                EventSystem.current.currentSelectedGameObject != null)
            {
                return;
            }
           
            // Fire the dart by enabling gravity, sending it forward, and de-parenting it from the camera:
            fired = true;
            rb.useGravity = true;
            rb.AddForce(transform.forward * thrust);
            this.gameObject.transform.parent = null;
            updateDartCounter();
            Invoke("DestroyDart", 3);
        }
    }
    
    // detect objects the dart collides with
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "DartBoard")
        {
            // Darts are frozen here, and tag is changed in collision detection of PointsAssigner.cs
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void DestroyDart()
    {
        Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0.55f, 0.45f,0.75f));

        GameObject MainCamera = GameObject.FindWithTag("MainCamera");
        GameObject newDart = Instantiate(dart, p, MainCamera.transform.rotation);
        newDart.transform.parent = MainCamera.transform;
        newDart.GetComponent<Rigidbody>().useGravity = false;
        newDart.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        // The new dart must be changed back to "Dart" tag from "InactiveDart" as assigned in PointsAssigner.cs
        newDart.gameObject.tag = "Dart";

        // Commented out to keep darts on board:
        //Destroy(this.gameObject);
    }

    public void updateDartCounter()
    {
        var dartCounterObject = GameObject.Find("DartManager");
        var dartCountScript = dartCounterObject.GetComponent<DartCounter>();

        dartCountScript.dartCounter -= 1;

        if (dartCountScript.dartCounter <= 0)
        {
            gameOver = true;
        }
         updateDartImages(dartCountScript.dartCounter);
    }

    public int getDartCounter()
    {
        var dartCounterObject = GameObject.Find("DartManager");
        var dartCountScript = dartCounterObject.GetComponent<DartCounter>();
        return dartCountScript.dartCounter;
    }

    public void updateDartImages(int counter){
        GameObject dartImgNum = GameObject.Find("DartImg" + counter);
        dartImgNum.SetActive(false);
    }
}