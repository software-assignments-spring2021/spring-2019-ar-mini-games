using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialManager : DartCounter
{
    public Text timer;
    float timeLimit = 30.0f;
    float timeLeft = 30.0f;
    private void Start()
    {
        timeLimit = 30.0f;
        timeLeft = 30.0f;
    }



    // Update is called once per frame
    void Update()
    {
        float timeLeft = timeLimit - Time.timeSinceLevelLoad;
        timer.text = (timeLeft).ToString("F2");
        if(timeLeft< 0.0)
        {
            timer.text = "0.0";
            gameOverPanel.SetActive(true);
        }
    }
}
