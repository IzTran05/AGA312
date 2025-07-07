using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{

    public float startTime = 60f;
    private float currentTime;

    public Text timerText;
   
    private bool isGameOver = false;
     
    void Start()
    {
        currentTime = startTime;
        //gameOverPanel.SetActive(false);
    }

  
    void Update()
    {
        if (isGameOver)
            return;
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0f, startTime);
        GameManager.Instance.UpdateTimerDisplay(currentTime);


        if (currentTime <= 0)
        {
            EndGame();
        }
    }

   

    void EndGame()
    {
        isGameOver = true;
        Debug.Log("Game Over!");

        GameManager.Instance.GameOver();
        //Time.timeScale = 0;
    }
}
