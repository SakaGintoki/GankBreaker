using System;
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

    private MainCharacterHealth playerHealth;
    private EnemyHealth enemyHealth;

    // Animation type (block or punch)
    private enum AnimationType { Block, Punch }
    private AnimationType animationType;

    void Start()
    {
        // Assign a random letter to the bubble
        bubbleKey = (char)('A' + UnityEngine.Random.Range(0, 26));
        bubbleText.text = bubbleKey.ToString();

        // Find the player's health system
        playerHealth = FindObjectOfType<MainCharacterHealth>();

        // Find the enemy's health system
        enemyHealth = FindObjectOfType<EnemyHealth>();

        // Randomly assign an animation type with higher probability for Block
        float randomValue = UnityEngine.Random.value; // Generates a random float between 0.0 and 1.0
        if (randomValue < 0.7f) // 70% chance
        {
            animationType = AnimationType.Block;
        }
        else // 30% chance
        {
            animationType = AnimationType.Punch;
        }

        // Optionally, you can change the bubble's appearance based on the animation type
        if (animationType == AnimationType.Punch)
        {
            bubbleText.color = Color.red; // Example: Change color for punch
        }
        else
        {
            bubbleText.color = Color.blue; // Example: Change color for block
        }
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
                if (animationType == AnimationType.Punch && enemyHealth != null)
                {
                    enemyHealth.TakeDamage(10); // Damage the enemy if punch animation
                }
                // No damage for block animation, just destroy the bubble
                Destroy(gameObject); // Remove the bubble
            }
            else if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Decrease health if wrong key pressed
                Destroy(gameObject); // Remove the bubble
            }
        }

        // Check if the time is up
        if (timer >= lifeTime && !keyPressed)
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Decrease health if time runs out
            }
            Destroy(gameObject); // Remove the bubble
        }
    }
}
