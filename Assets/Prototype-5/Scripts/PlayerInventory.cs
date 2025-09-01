using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<string> collectedFuses = new List<string>();

    public void CollectFuse(string fuseName)
    {
        if (!collectedFuses.Contains(fuseName))
            collectedFuses.Add(fuseName);
    }

    public bool HasFuse(string fuseName)
    {
        return collectedFuses.Contains(fuseName);
    }

    public void UseFuse(string fuseName)
    {
        collectedFuses.Remove(fuseName);
    }
}
