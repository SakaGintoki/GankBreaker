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

    void Start()
    {
        // Assign a random letter to the bubble
        bubbleKey = (char)('A' + Random.Range(0, 26));
        bubbleText.text = bubbleKey.ToString();

        // Find the player's health system
        playerHealth = FindObjectOfType<HealthSystem>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.anyKeyDown && !keyPressed)
        {
            // Check if the pressed key is correct
            if (Input.GetKeyDown(bubbleKey.ToString().ToLower()) || Input.GetKeyDown(bubbleKey.ToString().ToUpper()))
            {
                Destroy(gameObject); // Remove the bubble
                keyPressed = true; // Mark as successfully pressed
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
