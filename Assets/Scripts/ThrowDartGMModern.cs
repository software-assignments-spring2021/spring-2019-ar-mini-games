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
    public bool gameOver = false;
    bool fired = false;
    public Text dartCounterText;
    public GameObject DartBoard;
    public GameObject MainCamera;
    bool hitBoard = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (hitBoard) { transform.position = new Vector3(DartBoard.transform.position.x, DartBoard.transform.position.y, DartBoard.transform.position.z -1 ); }

        if (!fired){
            this.gameObject.transform.SetParent(MainCamera.transform);
        }
        if (Input.GetMouseButtonDown(0) && !fired)
        {
           
            Debug.Log("pressed");
            if (EventSystem.current.IsPointerOverGameObject() ||
                EventSystem.current.currentSelectedGameObject != null)
            {
               
                return;
            }
           
            fired = true;
            rb.useGravity = true;
            rb.AddForce(transform.forward * thrust);
            this.gameObject.transform.parent = null;

            updateDartCounter();
            Invoke("DestroyDartSetup", 1);
        }
    }
    
    // detect objects the dart collides with
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "DartBoard")
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            // Turn off collider and stop dart
            rb.velocity = Vector3.zero;

            // make dart "stick" to board by turning off gravity, movement, rotation
            rb.useGravity = false;

            rb.freezeRotation = true;

            hitBoard = true;

        } // end of if dartboard
    }

    void DestroyDartSetup()
    {
        getNewDart();
        Invoke("DestroyDart", 3);
    }

    void DestroyDart(){
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
        int currentDartCount = Convert.ToInt32(dartCounterText.text);
        dartCounterText.text = Convert.ToString(currentDartCount-1);

       
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

    public GameObject getNewDart()
    {
        Vector3 p = Camera.main.ViewportToWorldPoint(new Vector3(0.55f, 0.45f,0.75f));
        GameObject dartCpy = this.gameObject;
        dartCpy.transform.SetParent(MainCamera.transform);
        dartCpy.GetComponent<Collider>().enabled = true;
        hitBoard = false;
        Instantiate(dartCpy, p, MainCamera.transform.rotation);

        return dartCpy;
    }
}