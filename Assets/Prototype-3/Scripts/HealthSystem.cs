using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{

    private HeartDisplay heartDisplay;

    private Renderer playerRenderer;
    private Color originalColor;

    public int maxHealth = 3;
    private int currentHealth;

    private Vector3 respawnPosition;

    private Rigidbody rb;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        respawnPosition = transform.position; // Default to starting pos

        playerRenderer = GetComponentInChildren<Renderer>();
        if (playerRenderer != null)
            originalColor = playerRenderer.material.color;

        heartDisplay = FindObjectOfType<HeartDisplay>();
        if (heartDisplay != null)
            heartDisplay.UpdateHearts(currentHealth);
    }

    public void SetRespawnPoint(Vector3 newPoint)
    {
        respawnPosition = newPoint;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player Health: " + currentHealth);

        if (playerRenderer != null)
            StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Respawn();
        }

        if (heartDisplay != null)
            heartDisplay.UpdateHearts(currentHealth);
    }

    IEnumerator FlashRed()
    {
        playerRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f); // Flash duration
        playerRenderer.material.color = originalColor;
    }

    [System.Obsolete]
    void Respawn()
    {
        Debug.Log("Respawning...");
        currentHealth = maxHealth;
        transform.position = respawnPosition;
        rb.velocity = Vector3.zero; // Reset velocity

        if (heartDisplay != null)
            heartDisplay.UpdateHearts(currentHealth);
    }
}
