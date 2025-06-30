using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float fallSpeed = 2f;

    private void Update()
    {

        float wind = WindManager.Instance != null ? WindManager.Instance.currentWind : 0f;

        Vector3 move = new Vector3(wind, -fallSpeed, 0f) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
