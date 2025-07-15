using UnityEngine;

public class PivotController : MonoBehaviour
{
    public Transform pivotPointA;
    public Transform pivotPointB;

    private Transform currentPivot;
    public float rotationSpeed = 50f;

    public float maxSpeed = 150f;
    public float accel = 100f;
    private float currentSpeed;

    void Start()
    {
        currentPivot = pivotPointA;
    }

    void Update()
    {
        // Rotate around the current pivot point
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateAroundPivot(Vector3.up);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateAroundPivot(-Vector3.up);
        }

        // Switch pivot point
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentPivot = (currentPivot == pivotPointA) ? pivotPointB : pivotPointA;
        }
    }

    void RotateAroundPivot(Vector3 direction)
    {
        transform.RotateAround(currentPivot.position, direction, rotationSpeed * Time.deltaTime);
    }
}