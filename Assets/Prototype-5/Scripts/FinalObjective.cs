using UnityEngine;

public class FinalObjective : MonoBehaviour
{
    public GameOverUI gameOverUI;

    private bool isCollected = false;

    void OnTriggerEnter(Collider other)
    {
        if (isCollected) return;

        if (other.CompareTag("Player"))
        {
            isCollected = true;
            Debug.Log("Objective collected!");

            gameObject.SetActive(false); // Hide the vaccine

            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver();
            }
        }
    }
}
