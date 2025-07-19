using UnityEngine;

public class VineSwing : MonoBehaviour
{
    public Transform vineAnchor;
    private SpringJoint joint;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (joint == null)
                AttachToVine();
            else
                DetachFromVine();
        }
    }

    void AttachToVine()
    {
        joint = gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = vineAnchor.position;

        joint.spring = 50f;
        joint.damper = 5f;
        joint.maxDistance = 2f;
    }

    void DetachFromVine()
    {
        Destroy(joint);
    }
}
