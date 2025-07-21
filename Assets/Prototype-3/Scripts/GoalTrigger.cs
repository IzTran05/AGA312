using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameObject gameOverUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameOverUI != null)
                gameOverUI.SetActive(true);

            Time.timeScale = 0f; // Pauses the game
        }
    }
}