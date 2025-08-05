using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager4 : MonoBehaviour
{
    public static GameManager4 Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI timerText;
    public BV.Range Fog;
    public float startTime = 120;

    public GameObject endGameScreen;

    private float timeRemaining;
    private bool gameActive = true;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        RenderSettings.fogEndDistance = Fog.max;

        timeRemaining = startTime;
    }

    void Update()
    {
        if (gameActive)
        {
            UpdateTimer();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            EndGame();
        }
    }

    void UpdateTimer()
    {
        timeRemaining -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeRemaining <= 0f)
        {
            EndGame();
        }

        UpdateFog();

        if(timeRemaining <= 0f)
        {
            EndGame();
        }
    }

    public void AddPoint()
    {
        if (!gameActive) return;

        score++;
        UpdateScoreUI();
        ShowFeedback("Correct!");
    }

    public void DeductPoint()
    {
        if (!gameActive) return;

        score--;
        UpdateScoreUI();
        ShowFeedback("Wrong!");
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    void ShowFeedback(string message)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.color = message == "Correct!" ? Color.green : Color.red;
            CancelInvoke(nameof(ClearFeedback));
            Invoke(nameof(ClearFeedback), 1f);
        }
    }

        float fogIntensity =60;
    void UpdateFog()
    {

        RenderSettings.fogEndDistance = MathX.Map(timeRemaining, 0, startTime, Fog.min, Fog.max);

       //float totalGameTime = timeRemaining;
       // fogIntensity = MathX.Map(fogIntensity,  0, 120, Fog.min, Fog.max);
       // Debug.Log("FogIntensity " + fogIntensity);
       //float progress = Mathf.Clamp01(1 - (timeRemaining / totalGameTime));
       //float fogDensity = Mathf.Lerp(Fog.min, Fog.max, progress);
       // float fogDensity = Mathf.Lerp(0.001f, 0.05f, progress);
       //RenderSettings.fogDensity = fogDensity;
    }

    void ClearFeedback()
    {
        if (feedbackText != null)
            feedbackText.text = "";
    }

    void EndGame()
    {
        gameActive = false;
        endGameScreen.SetActive(true);
    }

    // Button functions
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu4"); 
    }
}
