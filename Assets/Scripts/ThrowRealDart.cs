using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowRealDart : MonoBehaviour
{
    private Rigidbody rb;
    public int thrust;
    public bool gameOver = false;
    bool fired = false; 

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !fired)
        {
            fired = true;
            Debug.Log("pressed");
            if (EventSystem.current.IsPointerOverGameObject() ||
                EventSystem.current.currentSelectedGameObject != null)
            {
                return;
            }
           
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
            
            // Turn off collider and stop dart
            rb.velocity = Vector3.zero;
            // make dart "stick" to board by turning off gravity, movement, rotation
            rb.useGravity = false;
            rb.freezeRotation = true;
        } // end of if dartboard
    }

    void DestroyDart()
    {
        Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0.55f, 0.45f,0.75f));

        GameObject MainCamera = GameObject.FindWithTag("MainCamera");
        GameObject dartCpy = Instantiate(this.gameObject, p, MainCamera.transform.rotation);
        dartCpy.transform.parent = MainCamera.transform;
        dartCpy.GetComponent<BoxCollider>().enabled = true;

        Destroy(this.gameObject);
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