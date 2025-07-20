using UnityEngine;

public class VineSwing : MonoBehaviour
{
    public float swingRange = 7f;
    public LayerMask vineLayer;
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
                TryAttachToVine();
            else
                DetachFromVine();
        }
    }


    void TryAttachToVine()
    {
        Collider[] vines = Physics.OverlapSphere(transform.position, swingRange, vineLayer);
        if (vines.Length > 0)
        {
            Transform closest = vines[0].transform;
            float minDist = Vector3.Distance(transform.position, closest.position);

            foreach (var vine in vines)
            {
                float dist = Vector3.Distance(transform.position, vine.transform.position);
                if (dist < minDist)
                {
                    closest = vine.transform;
                    minDist = dist;
                }
            }

            AttachToVine(closest);
        }
    }

    void AttachToVine(Transform anchor)
    {
        joint = gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = anchor.position;

        joint.spring = 100f;
        joint.damper = 5f;
        joint.maxDistance = 2.5f;
    }

    void DetachFromVine()
    {
        Destroy(joint);

        Vector3 forwardSwing = transform.forward + Vector3.up;
        rb.AddForce(forwardSwing * 5f, ForceMode.VelocityChange);
    }
}
