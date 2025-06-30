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
    public int maxMisses = 10;  

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverPanel;

    private bool isGameOver = false;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Start()
    {
        InvokeRepeating(nameof(IncreaseDifficulty), difficultyInterval, difficultyInterval);
    }

    void IncreaseDifficulty()
    {
        if (!isGameOver)
        {
        difficultyMultiplier += difficultyIncreaseRate;
        Debug.Log("Difficulty increased to: " + difficultyMultiplier);
        }
    }

    public void DeductScore(int value)
    {
        score -= value;
        if (score < 0) score = 0;
        UpdateScoreUI();
    }


    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    public void LeafMissed()
    {
        if (isGameOver) return;

        misses++;
        Debug.Log("Leaf Missed!");

        if (misses >= maxMisses)
        {
            Debug.Log("Gamer Over");
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
        isGameOver = true;
        Time.timeScale = 0f;
        
        if (gameOverPanel != null)
        gameOverPanel.SetActive(true);

        if (gameOverText)
        gameOverText.text = $"Game Over! Final Score: {score}";
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
