using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartCounter : MonoBehaviour
{

    public int dartCounter = 5;
    public GameObject gameOverPanel;
    // Start is called before the first frame update




    void Update()
    {

        if (dartCounter <= 0){
           
            gameOverPanel.SetActive(true);
        }
        
    }


}
