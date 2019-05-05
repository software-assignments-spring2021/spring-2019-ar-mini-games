using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartCounter : MonoBehaviour
{

    public int dartCounter = 3;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    ThrowDartGMModern dartScript;


     void Start()
    {
        dartScript = GetComponent<ThrowDartGMModern>();
    }

    void Update()
    {

        if (dartCounter <= 0 && ThrowDartGMModern.gameOver == true){
           
            gameOverPanel.SetActive(true);
        }






        
    }




}
