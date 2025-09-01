using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public Transform orientation;

    private CharacterController controller;
    private Camera mainCam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCam = Camera.main;
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveDirection = orientation.forward * input.y + orientation.right * input.x;

        if (moveDirection.magnitude >= 0.1f)
        {
            controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        // Rotate orientation with camera
        Vector3 camForward = mainCam.transform.forward;
        camForward.y = 0;
        orientation.forward = camForward;
    }
}
