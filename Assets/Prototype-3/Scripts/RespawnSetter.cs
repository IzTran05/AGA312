using UnityEngine;

public class RespawnSetter : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        HealthSystem health = other.GetComponent<HealthSystem>();
        if (health != null)
        {
            health.SetRespawnPoint(transform.position);
        }
    }
}

