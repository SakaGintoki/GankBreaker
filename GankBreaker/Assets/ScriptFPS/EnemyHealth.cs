using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider EnemyHealthSlider;
    [SerializeField] public UnityEvent OnDead;

    void Start()
    {
        currentHealth = maxHealth;
        EnemyHealthSlider = GetComponent<Slider>();
        EnemyHealthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void UpdateHealthUI()
    {
        EnemyHealthSlider.value = (float)currentHealth / maxHealth;
    }

    void Die()
    {
        // Logic when the enemy dies
        Debug.Log("Enemy Defeated");
        OnDead.Invoke();
        // Optionally, trigger other game events here, like stopping the game or showing a victory screen.
        BubbleSpawner spawner = FindObjectOfType<BubbleSpawner>();
        spawner.StopSpawning();  // Stop spawning bubbles when the enemy is defeated
    }
}
