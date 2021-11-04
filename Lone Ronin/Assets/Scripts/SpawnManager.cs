using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] oniPrefabs;
    private float spawnRange = 3.5f;

    public void Start()
    {
        SpawnEnemyWave();
    }

    void SpawnEnemyWave() {
        Vector3 spawnPos;
        int oniIndex;
        // Randomly generate oni index and spawn position
        for (int i = 0; i < 20; i++) {
            spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0.1f, Random.Range(-spawnRange, spawnRange));
            oniIndex = Random.Range(0, oniPrefabs.Length);
            Instantiate(oniPrefabs[oniIndex], spawnPos, oniPrefabs[oniIndex].transform.rotation);
        }
    }
}
