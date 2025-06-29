using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * input * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Leaf"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.AddScore(1);
        }
    }
}
