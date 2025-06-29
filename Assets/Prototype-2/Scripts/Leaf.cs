using UnityEngine;

public class Leaf : MonoBehaviour
{
    public float fallSpeed = 2f;
    public int pointValue = 1;
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
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
