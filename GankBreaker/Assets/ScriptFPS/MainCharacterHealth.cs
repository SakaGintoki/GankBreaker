using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterHealth: MonoBehaviour
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
            Die();
        }
    }

    void UpdateHealthUI()
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }

    void Die()
    {
        // Logic when the enemy dies
        Debug.Log("Game Over");
        // Optionally, trigger other game events here, like stopping the game or showing a victory screen.
        BubbleSpawner spawner = FindObjectOfType<BubbleSpawner>();
        spawner.StopSpawning();  // Stop spawning bubbles when the enemy is defeated
    }
}
