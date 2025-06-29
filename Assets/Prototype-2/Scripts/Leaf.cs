using UnityEngine;

public class Leaf : MonoBehaviour
{
    public float fallSpeed = 2f;
    public int pointValue = 1;
    void Update()
    {
        float wind = WindManager.Instance != null ? WindManager.Instance.currentWind : 0f;

            Vector3 move = new Vector3(wind, -fallSpeed, 0f) * Time.deltaTime;
        transform.Translate(move, Space.World);
        //transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            GameManager.Instance.LeafMissed();
            Destroy(gameObject);
        }
    }
}
