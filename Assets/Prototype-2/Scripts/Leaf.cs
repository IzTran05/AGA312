using UnityEngine;

public class Leaf : MonoBehaviour
{
    public float fallSpeed = 2f;
    public int pointValue = 1;
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            Destroy(gameObject); 
        }
    }
}
