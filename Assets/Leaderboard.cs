//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SocialPlatforms;

//public class Leaderboard : MonoBehaviour
//{
//    void Start()
//    {
//        // Authenticate and register a ProcessAuthentication callback
//        // This call needs to be made before we can proceed to other calls in the Social API
//        Social.localUser.Authenticate(ProcessAuthentication);
//    }

//    // This function gets called when Authenticate completes
//    // Note that if the operation is successful, Social.localUser will contain data from the server. 
//    void ProcessAuthentication(bool success)
//    {
//        if (success)
//        {
//            Debug.Log("Authenticated, checking achievements");

//            // Request loaded achievements, and register a callback for processing them
//          //  Social.LoadAchievements(ProcessLoadedAchievements);

//            ILeaderboard leaderboard = Social.CreateLeaderboard();
//            leaderboard.id = "grp.leaderboard1";
//            leaderboard.LoadScores(result =>
//            {
//                Debug.Log("Received " + leaderboard.scores.Length + " scores");
//                foreach (IScore score in leaderboard.scores)
//                    Debug.Log(score);
//            });

//        }
//        else
//            Debug.Log("Failed to authenticate");
//    }

//    // This function gets called when the LoadAchievement call completes
//    void ProcessLoadedAchievements(IAchievement[] achievements)
//    {
//        if (achievements.Length == 0)
//            Debug.Log("Error: no achievements found");
//        else
//            Debug.Log("Got " + achievements.Length + " achievements");

//        // You can also call into the functions like this
       
//    }
//}
