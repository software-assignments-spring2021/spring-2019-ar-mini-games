using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System;

public class ThrowRealDart : MonoBehaviour
{
    private Rigidbody rb;
    private Scene scene;
    public int thrust;
    public static bool gameOver = false;
    public Text dartCounterText;
    public GameObject DartBoard;
    bool fired = false;
    bool hitDart = false;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        rb = this.GetComponent<Rigidbody>();
        Transform cameraChildTransform = transform;
    }

    public void Throw()
    {
        // click screen to throw dart
        if (!fired)
        {
            if (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.currentSelectedGameObject != null)
            {
                return;
            }
            fired = true;

            rb.useGravity = true;
            rb.AddForce(transform.forward * thrust);
            this.gameObject.transform.parent = null;
            updateDartCounter();
            Invoke("DestroyDart", 1);

        }
    }

    // detect objects the dart collides with
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "DartBoard" && !hitDart)
        {
            // Darts are frozen here, and tag is changed in collision detection of PointsAssigner.cs
            gameObject.GetComponent<BoxCollider>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            transform.SetParent(DartBoard.transform);
            transform.localScale = new Vector3(80, 80, 80);
            if (scene.name == "GameModeModern")
            {
                if (col.gameObject.name == "InnerBoard")
                {
                    Debug.Log("hit the inner board yes");
                    restockDarts();
                }
            }
        } // end of if dartboard
        if (col.gameObject.tag == "InactiveDart")
        {
            hitDart = true;
            gameObject.tag = "InactiveDart"; // Deactivate the dart from scoring
            rb.AddForce(transform.forward * -5);
        }
    }

    void restockDarts()
    {
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
        Vector3 pos = new Vector3(0.032f, -0.05f, 0.861f);
        dartCpy.transform.localScale = new Vector3(80, 80, 80);
        dartCpy.GetComponent<BoxCollider>().enabled = true;
        dartCpy.GetComponent<Rigidbody>().useGravity = false;
        dartCpy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        dartCpy.transform.position = pos;

        // The new dart must be changed back to "Dart" tag from "InactiveDart" as assigned in PointsAssigner.cs
        dartCpy.gameObject.tag = "Dart";
        print(scene.name);
        if (scene.name == "GameModeModern")
        {
            print("check");
            Destroy(this.gameObject);
        }
    }

    void updateDartCounter()
    {
        var dartCounterObject = GameObject.Find("DartManager");
        var dartCountScript = dartCounterObject.GetComponent<DartCounter>();
        dartCountScript.dartCounter -= 1;
        Debug.Log("dart counter " + dartCountScript.dartCounter);
        dartCounterText.text = Convert.ToString(dartCountScript.dartCounter);
        Invoke("isGameOver", 2);
    }

    void isGameOver()
    {
        var dartCounterObject = GameObject.Find("DartManager");
        var dartCountScript = dartCounterObject.GetComponent<DartCounter>();
        if (dartCountScript.dartCounter <= 0)
        {
            gameOver = true;
        }
        else
        {
            gameOver = false;
        }
    }
}
