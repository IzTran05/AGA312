using TMPro;
using UnityEngine;
using System.Collections.Generic;
public class GameManager4 : MonoBehaviour
{
    public static GameManager4 Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        // Make sure there's only one GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
