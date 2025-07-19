using UnityEngine;

public class PlayerController3 : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    private HingeJoint vineJoint;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) ;
        Jump();

        if (Input.GetKeyDown(KeyCode.E))
            TryGrabVine();

        if (Input.GetKeyDown(KeyCode.Q))
            ReleaseVine();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horizontal, 0, vertical);
        rb.MovePosition(transform.position + dir * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void TryGrabVine()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 2f);
        foreach(var hit in hits)
        {
            if (hit.CompareTag("Vine"))
            {
                vineJoint = gameObject.AddComponent<HingeJoint>();
                vineJoint.connectedBody = hit.GetComponent<Rigidbody>();
                vineJoint.anchor = Vector3.up * 1f;
                vineJoint.axis = Vector3.forward;
                break;
            }
        }
    }

    void ReleaseVine()
    {
        if (vineJoint != null)
            Destroy(vineJoint);
    }
    
}
