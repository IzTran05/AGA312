using UnityEngine;

public class VineSway : MonoBehaviour
{
    public Transform vineMesh; // The cylinder 
    public Transform player;
    public float maxTiltAngle = 15f;
    public float swaySpeed = 5f;

    private Quaternion originalRotation;

    void Start()
    {
        if (vineMesh != null)
            originalRotation = vineMesh.localRotation;
    }

    void Update()
    {
        if (vineMesh == null || player == null)
            return;

        Vector3 toPlayer = player.position - transform.position;
        toPlayer.Normalize();

        // Calculate target rotation as tilt in the swing direction
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer);
        Vector3 tiltEuler = targetRotation.eulerAngles;
        tiltEuler.x = Mathf.Clamp(tiltEuler.x, -maxTiltAngle, maxTiltAngle);
        tiltEuler.z = Mathf.Clamp(tiltEuler.z, -maxTiltAngle, maxTiltAngle);
        tiltEuler.y = 0; // Don't twist the rope

        Quaternion swayRotation = Quaternion.Euler(tiltEuler);

        // Smoothly sway the vine mesh toward the target rotation
        vineMesh.localRotation = Quaternion.Slerp(vineMesh.localRotation, swayRotation, Time.deltaTime * swaySpeed);
    }

    public void ResetVine()
    {
        vineMesh.localRotation = originalRotation;
    }
}
