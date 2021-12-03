using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    private float currentHealth;
    public float MaxHealth;
    PlayerHealth player;
    
    void Start() {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerHealth>();
        currentHealth = MaxHealth;
    }

    void Update() {
        currentHealth = player.health;
        healthBar.fillAmount = currentHealth / MaxHealth;

        if (currentHealth <= 0) {
            player.GameOver(0);
        }
    }
}
