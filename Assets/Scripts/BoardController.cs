using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
    private int score;
    private int highScore;
    public Text scoreText;
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = 0;
    }

    public void UpdateScore(int newPoints)
    {
        Debug.Log(newPoints);
        score += newPoints;

        if (score > highScore)
        {
<<<<<<< HEAD:Assets/Scripts/BoardController.cs
            highScore = score;
=======
            score = score + 1;
            if (score > highScore)
            {
                highScore = score;               
            }
            showText();
>>>>>>> master:Assets/BoardController.cs
        }
        showText();
    }

    private void showText ()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}

