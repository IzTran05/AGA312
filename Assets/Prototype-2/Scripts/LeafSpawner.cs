using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
    public GameObject leafPrefab;
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
        Instantiate(leafPrefab, spawnPos, Quaternion.identity);
    }
}
