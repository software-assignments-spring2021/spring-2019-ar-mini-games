using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
    public int score;
    private int highScore;
    public Text scoreText;
    public Text highScoreText;
    bool fired = false;


    public int Score { get => score; }
    public int HighScore { get => highScore; }

    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
        loadHighscore();
        showText();
    }

    public void UpdateScore(int newPoints)
    {
        Debug.Log(newPoints);
        score += newPoints;

        if (score > highScore)
        {
            highScore = score;
            saveHighscore();
        }
        showText();
    }

    private void showText()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    private void saveHighscore()
    {
        PlayerPrefs.SetInt("highscore", highScore);
    }

    //initialize the high score
    private void loadHighscore()
    {
        highScore = PlayerPrefs.GetInt("highscore");
    }
}

