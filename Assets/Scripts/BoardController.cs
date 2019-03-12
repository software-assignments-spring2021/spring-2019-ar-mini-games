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

    // Get/Set for private vars:
    public int Score { get => score; set => score = value; }
    public int HighScore { get => highScore; set => highScore = value; }

    void Start()
    {
        Score = 0;
        HighScore = 0;
    }

    public void UpdateScore(int newPoints)
    {   
        if (newPoints >= 0)
        {
            if ((Score += newPoints) > HighScore)
            {
                HighScore = Score;
                UpdateHighScoreText();
            }
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + Score.ToString();
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + HighScore.ToString();
    }
}



