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

    // Animation type (block or punch)
    private enum AnimationType { Block, Punch }
    private AnimationType animationType;

    void Start()
    {
        // Assign a random letter to the bubble
        bubbleKey = (char)('A' + Random.Range(0, 26));
        bubbleText.text = bubbleKey.ToString();

        // Find the player's health system
        playerHealth = FindObjectOfType<HealthSystem>();

        // Find the enemy's health system
        enemyHealth = FindObjectOfType<EnemyHealth>();

        // Randomly choose an animation type
        animationType = (Random.Range(0, 2) == 0) ? AnimationType.Block : AnimationType.Punch;

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
                if (animationType == AnimationType.Punch)
                {
                    enemyHealth.TakeDamage(5); // Damage the enemy if punch animation
                }
                // No damage for block animation, just destroy the bubble
                Destroy(gameObject); // Remove the bubble
            }
            else
            {
                playerHealth.TakeDamage(10); // Decrease health if wrong key pressed
                Destroy(gameObject); // Remove the bubble
            }
        }

        // Check if the time is up
        if (timer >= lifeTime && !keyPressed)
        {
            playerHealth.TakeDamage(10); // Decrease health if time runs out
            Destroy(gameObject); // Remove the bubble
        }
    }
}
