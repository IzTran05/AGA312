using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player
    public Vector3 offset;
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target != null) return;
        transform.position = target.position + offset;
    }
}
