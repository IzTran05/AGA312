using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float difficultyMultiplier = 1f;
    public float difficultyIncreaseRate = 0.05f;
    public float difficultyInterval = 5f;

    public int score = 0;
    public int misses = 0;
    public int maxMisses = 5;  

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverPanel;


    private void Start()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
        InvokeRepeating(nameof(IncreaseDifficulty), difficultyInterval, difficultyInterval);
    }

    void IncreaseDifficulty()
    {
        difficultyMultiplier += difficultyIncreaseRate;
        Debug.Log("Difficulty increased to: " + difficultyMultiplier);
    }




    private void Awake()
    {
        Instance = this;
        gameOverPanel.SetActive(false);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    public void LeafMissed()
    {
        misses++;
        if (misses >= maxMisses)
        {
            GameOver();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        gameOverText.text = $"Game Over!\nFinal Score: {score}";
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
