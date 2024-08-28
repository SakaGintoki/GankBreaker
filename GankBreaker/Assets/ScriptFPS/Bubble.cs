using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    public Text bubbleText;
    public char bubbleKey; // The key that will be displayed in the bubble
    public float lifeTime = 1f; // Time within which the player must press the correct key
    private float timer;
    private bool keyPressed = false;

    private HealthSystem playerHealth;
    private EnemyHealth enemyHealth;

    void Start()
    {
        // Assign a random letter to the bubble
        bubbleKey = (char)('A' + Random.Range(0, 26));
        bubbleText.text = bubbleKey.ToString();

        // Find the player's health system
        playerHealth = FindObjectOfType<HealthSystem>();

        // Find the enemy's health system
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.anyKeyDown && !keyPressed)
        {
            // Check if the pressed key is correct
            if (Input.GetKeyDown(bubbleKey.ToString().ToLower()) || Input.GetKeyDown(bubbleKey.ToString().ToUpper()))
            {
                keyPressed = true; // Mark as successfully pressed

                // Check if enemyHealth is not null before accessing it
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(10); // Damage the enemy
                }

                Destroy(gameObject); // Remove the bubble
            }
            else
            {
                // Check if playerHealth is not null before accessing it
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(10); // Decrease health if wrong key pressed
                }

                Destroy(gameObject); // Remove the bubble
            }
        }

        // Check if the time is up
        if (timer >= lifeTime && !keyPressed)
        {
            // Check if playerHealth is not null before accessing it
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Decrease health if time runs out
            }

            Destroy(gameObject); // Remove the bubble
        }
    }
}
