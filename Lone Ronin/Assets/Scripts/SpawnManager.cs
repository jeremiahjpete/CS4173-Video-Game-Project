using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] oniPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    public void Start()
    {
        SpawnEnemyWave();
    }

    void SpawnEnemyWave() {
        // Randomly generate oni index and spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int oniIndex = Random.Range(0, oniPrefabs.Length);
        for (int i = 0; i < 20; i++) {
            Instantiate(oniPrefabs[oniIndex], spawnPos, oniPrefabs[oniIndex].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
