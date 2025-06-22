using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timer;

    public int score;
    public float timeRemaining = 60;
 
    void Start()
    {
        UpdateScore(0);
        UpdateTime(timeRemaining);
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTime(timeRemaining);
        }
        else
        {
            UpdateTime(0);
            GameOver();
        }
    }

    public void UpdateScore(int scoreAdd)
    {
        //score += scoreToAdd;
        scoreText.text = "Score: " + score; 
    }

    public void UpdateTime(float timeLeft)
    {
        timer.text = "Time remaining: " + timeLeft;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
