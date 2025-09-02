using UnityEngine;

public class LaserHazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit by laser!");

            // Find the GameOverUI and show it
            DeathScreenUI deathScreen = FindObjectOfType<DeathScreenUI>();
            if (deathScreen != null)
            {
                deathScreen.ShowDeathScreen();
            }
        }
    }
}
