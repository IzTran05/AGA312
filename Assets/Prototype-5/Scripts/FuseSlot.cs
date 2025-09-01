using UnityEngine;

public class FuseSlot : MonoBehaviour
{
    public string requiredFuseID;
    public bool isFilled = false;
    public Material filledMaterial;

    public Light slotLight;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (slotLight != null)
            slotLight.enabled = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (!isFilled && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            var inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.HasFuse(requiredFuseID))
            {
                inventory.UseFuse(requiredFuseID);
                isFilled = true;

                if (filledMaterial != null && rend != null)
                    rend.material = filledMaterial;

                if (slotLight != null)
                    slotLight.enabled = true;

                PuzzleManager.Instance.CheckPuzzleComplete();
            }
        }
    }
}
