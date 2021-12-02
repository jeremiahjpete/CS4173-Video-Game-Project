using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] oniPrefabs;
    private float spawnRange = 3.5f;
    public int enemyCount;
    public TextMeshProUGUI countText;
    public GameObject zeroDisplay;

    void Start()
    {
        zeroDisplay.SetActive(false);
        SpawnEnemyWave(enemyCount);
        UpdateCount(0);
    }

    void Update() {
        if (enemyCount == 0) {
            zeroDisplay.SetActive(true);
            Debug.Log("All enemies defeated! Loading next level...");
            Invoke(nameof(DisplayNextLevel), 4f);
        }
    }

    void SpawnEnemyWave(int count) {
        Vector3 spawnPos;
        int oniIndex;
        // Randomly generate oni index and spawn position
        for (int i = 0; i < count; i++) {
            spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0.1f, Random.Range(-spawnRange, spawnRange));
            oniIndex = Random.Range(0, oniPrefabs.Length);
            Instantiate(oniPrefabs[oniIndex], spawnPos, oniPrefabs[oniIndex].transform.rotation);
        }
    }

    public void UpdateCount(int count) {
        enemyCount -= count;
        countText.text = "Enemies Remaining: " + enemyCount;
        Debug.Log("Enemies Remaining: " + enemyCount);
    }

    void DisplayNextLevel() {
        SceneManager.LoadScene(2);
    }
}
