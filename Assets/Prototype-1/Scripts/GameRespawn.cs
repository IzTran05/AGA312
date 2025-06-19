using UnityEngine;

public class GameRespawn : MonoBehaviour
{

    public float threshold;

    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(0.0f, 0.4f, 0.0f);
        }
    }
}
