using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialManager : DartCounter
{
    public Text timer;
    public float timeLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        float timeLeft = timeLimit - Time.fixedTime;
        timer.text = (timeLeft).ToString("F2");
        if(timeLeft< 0.0)
        {
            timer.text = "0.0";
            gameOverPanel.SetActive(true);
        }
    }
}
