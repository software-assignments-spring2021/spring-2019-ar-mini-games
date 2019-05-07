using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.GameCenter;
using System;

public class RecordScoreLeaderboard : MonoBehaviour
{


    public string leaderboardID = "grp.leaderboard1";

    void Start()
    {
        AuthenticateToGameCenter();
    }


    private bool isAuthenticatedToGameCenter;

    public static void AuthenticateToGameCenter()
    {
#if UNITY_IPHONE
        Social.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Authentication successful");
            }
            else
            {
                Debug.Log("Authentication failed");

            }
        });
#endif
    }

    //call to update the leaderboard with your score
    public static void ReportScore(long score, string leaderboardID)
    {
        Debug.Log("in report score");
#if UNITY_IPHONE
        //Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Social.ReportScore(score, leaderboardID, success => {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
            //Social.ShowLeaderboardUI();
            //ShowLeaderboard();
            GameCenterPlatform.ShowLeaderboardUI("grp.leaderboard1", TimeScope.AllTime); 

        });
#endif
    }

    //call to show leaderboard
    public static void ShowLeaderboard()
    {
        ILeaderboard leaderboard = Social.CreateLeaderboard();
        leaderboard.id = "grp.leaderboard1";
        Debug.Log("in show leaderboard");
        leaderboard.LoadScores(result =>
        {
            Debug.Log("Received " + leaderboard.scores.Length + " scores");
            foreach (IScore score in leaderboard.scores)
                Debug.Log(score);
        });
        //Social.ShowLeaderboardUI();
        GameCenterPlatform.ShowLeaderboardUI("grp.leaderboard1", TimeScope.Today); 


#if UNITY_IPHONE
        //Social.ShowLeaderboardUI();
#endif
    }

}

