using UnityEngine;

public class Leaf : MonoBehaviour
{
    public float fallSpeed = 2f;
    public int pointValue = 1;
    private bool hasLanded = false;
    void Update()
    {
        float wind = WindManager.Instance != null ? WindManager.Instance.currentWind : 0f;

        transform.Translate(new Vector3(wind, -fallSpeed, 0f) * Time.deltaTime);
        //transform.Translate(move, Space.World);
        //transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasLanded && other.CompareTag("Ground"))
        {
            hasLanded = true;

            if (gameObject.CompareTag("Leaf"))
            {
            GameManager.Instance.LeafMissed();
            }

            Destroy(gameObject);
        }
    }
}
