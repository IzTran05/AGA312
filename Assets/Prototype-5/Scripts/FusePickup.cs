using UnityEngine;
using System.Collections.Generic;

public class FusePickup : MonoBehaviour
{
    public string fuseID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.CollectFuse(fuseID);
                Destroy(gameObject); // Remove fuse
            }
        }
    }
}
