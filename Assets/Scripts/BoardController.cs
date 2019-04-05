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
        score += newPoints;

        if (score > highScore)
        {

            score = score + 1;
            if (score > highScore)
            {
                highScore = score;               
            }
            showText();
        }
        showText();
    }

    private void showText ()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}

