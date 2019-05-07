using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartCounter : MonoBehaviour
{

    public int dartCounter = 3;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    ThrowDartGMModern dartScript;
    int score;
    bool set = false;

     void Start()
    {
        dartScript = GetComponent<ThrowDartGMModern>();

    }

    void Update()
    {

        if (dartCounter <= 0 && ThrowDartGMModern.gameOver == true ||ThrowRealDart.gameOver == true && !set ){
           
            gameOverPanel.SetActive(true);
            long score1 = 10;
           // RecordScoreLeaderboard.AuthenticateToGameCenter();
            RecordScoreLeaderboard.ReportScore(score1, "grp.leaderboard1");
            set = true;



        }






        
    }




}
