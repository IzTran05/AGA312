using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject[] powerUpPrefabs;
    private int randomPowerup;

    void Start()
    {
        int randomPowerup = Random.Range(0, powerUpPrefabs.Length);
        Instantiate(powerUpPrefabs[randomPowerup], GenerateSpawnPosition(), powerUpPrefabs[randomPowerup].transform.rotation);
        SpawnEnemyWave(waveNumber);
    }


    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefabs[randomPowerup], GenerateSpawnPosition(), powerUpPrefabs[randomPowerup].transform.rotation); 
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefab.Length);

            Instantiate(enemyPrefab[randomEnemy], GenerateSpawnPosition(), enemyPrefab[randomEnemy].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
