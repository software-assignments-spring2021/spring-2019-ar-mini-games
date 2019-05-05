using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using System; 

public class ThrowDartGMModern : MonoBehaviour
{
    private Rigidbody rb;
    public int thrust;
    public static bool gameOver = false;
    public Text dartCounterText;
    public GameObject DartBoard;
    public GameObject MainCamera;
    bool fired = false; 

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Transform cameraChildTransform = transform;

    }


    // Update is called once per frame
    void Update()
    {
        // click screen to throw dart
        if (Input.GetMouseButtonDown(0) && !fired)
        {
            if (EventSystem.current.IsPointerOverGameObject() ||
             EventSystem.current.currentSelectedGameObject != null)
            {
                return;
            }
                 fired = true;
            
                Debug.Log("pressed");
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

        if (col.gameObject.name == "InnerBoard")
        {
            Debug.Log("hit the inner board yes");
            restockDarts();

        }
        else if (col.gameObject.tag == "DartBoard")
        {
            // Turn off collider and stop dart
            gameObject.GetComponent<BoxCollider>().enabled = false;
            rb.velocity = Vector3.zero;
            // make dart "stick" to board by turning off gravity, movement, rotation
            rb.useGravity = false;
            rb.freezeRotation = true;
          
            transform.SetParent(DartBoard.transform);
            transform.localScale = new Vector3(80, 80, 80);

        } // end of if dartboard



    }

    void restockDarts(){
        var dartCounterObject = GameObject.Find("DartManager");
        var dartCountScript = dartCounterObject.GetComponent<DartCounter>();
        dartCountScript.dartCounter = 3;
        dartCounterText.text = Convert.ToString(dartCountScript.dartCounter);
    }

    void DestroyDart()
    {
        
        Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.45f, 0.8f));
        GameObject dartCpy = Instantiate(this.gameObject, p, Camera.main.transform.rotation);
        dartCpy.transform.parent = GameObject.FindWithTag("MainCamera").transform;
        dartCpy.transform.localScale = new Vector3(80, 80, 80);
        dartCpy.GetComponent<BoxCollider>().enabled = true;
        Destroy(this.gameObject);
    }

    public void updateDartCounter()
    {
        var dartCounterObject = GameObject.Find("DartManager");
        var dartCountScript = dartCounterObject.GetComponent<DartCounter>();
        dartCountScript.dartCounter -= 1;
        Debug.Log("dart counter " + dartCountScript.dartCounter);
        dartCounterText.text = Convert.ToString(dartCountScript.dartCounter);
        Invoke("isGameOver", 2);

       
    }

    void isGameOver(){
        var dartCounterObject = GameObject.Find("DartManager");
        var dartCountScript = dartCounterObject.GetComponent<DartCounter>();
        if (dartCountScript.dartCounter <= 0)
        {
          gameOver = true;
        }
    }

 
}

