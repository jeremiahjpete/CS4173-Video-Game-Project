using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log("Enemy Hit!");

        if (health <= 0) {
            Invoke(nameof(GameOver), 2f);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Oni") {
            TakeDamage(1);
        }
    }

    public void GameOver(int scene) {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(scene);
    }
}
