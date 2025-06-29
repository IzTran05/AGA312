using UnityEngine;
using System.Collections.Generic;

    [System.Serializable]
    public class LeafType
    {
        public GameObject prefab;
        public float weight;
    }
public class LeafSpawner : MonoBehaviour
{
    public List<LeafType> leafTypes = new List<LeafType>();
    public float spawnInterval = 1.5f;
    public float spawnRange = 5f;
    void Start()
    {
        InvokeRepeating("SpawnLeaf", 1f, spawnInterval);
    }


    void SpawnLeaf()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(xPos, transform.position.y, 0);

        GameObject selectedLeaf = GetWeightedRandomLeaf();
        GameObject leafObj = Instantiate(selectedLeaf, spawnPos, Quaternion.identity);

        //Adjusting falling speed based on difficulty
        Leaf leafScript = leafObj.GetComponent<Leaf>();
        if (leafScript != null)
        {
            leafScript.fallSpeed *= GameManager.Instance.difficultyMultiplier;
        }
    }

    GameObject GetWeightedRandomLeaf()
    {
        float totalWeight = 0f;

        foreach (var leaf in leafTypes)
        totalWeight += leaf.weight;

        float randomValue = Random.Range(0f, totalWeight);
        float cumulative = 0f;

        foreach (var leaf in leafTypes)
        {
            cumulative += leaf.weight;
            if (randomValue <= cumulative)
                return leaf.prefab;

        }

        return leafTypes[0].prefab;
    }
}
