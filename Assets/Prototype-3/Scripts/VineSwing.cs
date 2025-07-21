using UnityEngine;
using System.Collections;

public class VineSwing : MonoBehaviour
{
    public float swingRange = 7f;
    public LayerMask vineLayer;
    private SpringJoint joint;
    private Rigidbody rb;

    [Header("Swing Control")]
    public float airControlForce = 10f;

    [Header("Optional Vine Visuals")]
    public Material grabbedMaterial;
    public Material defaultMaterial;

    private Transform currentVineAnchor;
    private Coroutine vineFlashCoroutine;
    private Renderer lastVineRenderer;

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

        if (joint != null)
        {
            ApplySwingControl();
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

        currentVineAnchor = anchor;

        // Tell the vine to track the player’s swing
        VineSway sway = anchor.GetComponent<VineSway>();
        if (sway != null)
            sway.player = transform;

        // Flash vine material
        lastVineRenderer = anchor.GetComponentInChildren<Renderer>();
        if (lastVineRenderer != null && grabbedMaterial != null)
            lastVineRenderer.material = grabbedMaterial;
    }

    void DetachFromVine()
    {
        if (currentVineAnchor != null)
        {
            VineSway sway = currentVineAnchor.GetComponent<VineSway>();
            if (sway != null)
                sway.ResetVine();

            if (lastVineRenderer != null && defaultMaterial != null)
                lastVineRenderer.material = defaultMaterial;
        }

        Destroy(joint);
        currentVineAnchor = null;
        lastVineRenderer = null;

        Vector3 forwardSwing = transform.forward + Vector3.up;
        rb.AddForce(forwardSwing * 5f, ForceMode.VelocityChange);
    }

    void ApplySwingControl()
    {
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (inputDir.sqrMagnitude > 0.01f)
        {
            Vector3 force = transform.TransformDirection(inputDir.normalized) * airControlForce;
            rb.AddForce(force, ForceMode.Acceleration);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            HealthSystem health = GetComponent<HealthSystem>();
            if (health != null)
            {
                health.TakeDamage(1);
            }
        }
    }

    /*IEnumerator FlashVineMaterial()
    {
        if (lastVineRenderer == null || grabbedMaterial == null || defaultMaterial == null)
            yield break;

        lastVineRenderer.material = grabbedMaterial;
        yield return new WaitForSeconds(0.5f);
        lastVineRenderer.material = defaultMaterial;
    }*/
}