using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartCounter : MonoBehaviour
{
    public int dartCounter = 3;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    ThrowRealDart dartScript;

     void Start()
    {
        dartScript = GetComponent<ThrowRealDart>();
    }

    void Update()
    {
        if (dartCounter <= 0 && ThrowRealDart.gameOver == true )
        {   
            gameOverPanel.SetActive(true);
        }
        //else
        //{
        //    gameOverPanel.SetActive(false);
        //}
    }
}
