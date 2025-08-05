using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 1f;
    public float mouseSensitivity = 3f;

    public Transform cameraPivot; 

    private CharacterController controller;
    private float verticalRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
       // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * v + transform.right * h;
        controller.Move(move * moveSpeed * Time.deltaTime);
    }

    void RotatePlayer()
    {
        float rotateInput = 0f;

        // Rotate with Q and E keys (or Left/Right arrows)
        if (Input.GetKey(KeyCode.Q))
            rotateInput = -1f;
        else if (Input.GetKey(KeyCode.E))
            rotateInput = 1f;

        transform.Rotate(Vector3.up * rotateInput * rotationSpeed);
    }
}
