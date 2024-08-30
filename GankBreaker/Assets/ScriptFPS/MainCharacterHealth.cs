using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacterHealth: MonoBehaviour
{
    public static int maxHealth = 100;
    public static int damage = 25;
    public int currentHealth;
    public Slider healthSlider; // Reference to the Slider UI element
    private MCAnimation mcAnimation;
    private EnemyAnimation enemyAnimation;

    private void Awake()
    {
        mcAnimation = FindObjectOfType<MCAnimation>();
        if (mcAnimation == null)
        {
            Debug.LogError("MCAnimation component not found in the scene!");
        }

        // Initialize enemyAnimation (if necessary)
        enemyAnimation = FindObjectOfType<EnemyAnimation>();
        if (enemyAnimation == null)
        {
            Debug.LogError("EnemyAnimation component not found in the scene!");
        }
    }

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
        increaseMCHealthAndDamage();
        // Logic when the enemy dies
        mcAnimation.SetAnimationDefault();
        enemyAnimation.SetAnimationDefault();

        Debug.Log("Game Over");
        // Optionally, trigger other game events here, like stopping the game or showing a victory screen.
        BubbleSpawner spawner = FindObjectOfType<BubbleSpawner>();
        spawner.StopSpawning();  // Stop spawning bubbles when the enemy is defeated
    }

    void increaseMCHealthAndDamage()
    {
        maxHealth += 5;
        damage += 5;
        
    }
}
