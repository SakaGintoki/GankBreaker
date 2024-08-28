using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider; // Reference to the Slider UI element

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); // Update the slider to reflect the starting health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            // Handle the player's defeat (e.g., show a Game Over screen)
            Debug.Log("Game Over");
        }
    }

    void UpdateHealthUI()
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }
}
