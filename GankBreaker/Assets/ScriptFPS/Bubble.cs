using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Text bubbleText;
    [SerializeField] private char bubbleKey; // The key that will be displayed in the bubble
    [SerializeField] private float lifeTime = 1f; // Time within which the player must press the correct key
    [SerializeField] private string firstPersonHandTag = "FirstPersonHand";
    [SerializeField] private Color PunchColor;
    [SerializeField] private Color ShieldColor;

    private float timer;
    private bool keyPressed = false;
    private Animator anim;

    private MainCharacterHealth playerHealth;
    private EnemyHealth enemyHealth;

    // Animation type (Block or Punch)
    private enum AnimationType { BlockAnimation, PunchAnimation }
    private AnimationType animationType;

    void Start()
    {
        GameObject firstPersonHand = GameObject.FindGameObjectWithTag(firstPersonHandTag);
        anim = firstPersonHand.GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator component missing from this GameObject!");
        }

        // bubbleKey = (char)('A' + UnityEngine.Random.Range(0, 26));
        bubbleText.text = "";

     
        playerHealth = FindObjectOfType<MainCharacterHealth>();
        if (playerHealth == null)
        {
            Debug.LogError("MainCharacterHealth component not found in the scene!");
        }

        enemyHealth = FindObjectOfType<EnemyHealth>();
        if (enemyHealth == null)
        {
            Debug.LogError("EnemyHealth component not found in the scene!");
        }

        float randomValue = UnityEngine.Random.value; 
        if (randomValue < 0.7f) 
        {
            bubbleKey = (char)('A');
            bubbleText.text = bubbleKey.ToString();
            animationType = AnimationType.BlockAnimation;
        }
        else 
        {
            bubbleKey = (char)('D');
            bubbleText.text = bubbleKey.ToString();
            animationType = AnimationType.PunchAnimation;
        }

        if (animationType == AnimationType.PunchAnimation)
        {
            bubbleText.color = Color.cyan; 
        }
        else
        {
            bubbleText.color = Color.white; // Example: Change color for block
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
                if (animationType == AnimationType.PunchAnimation && enemyHealth != null)
                {
                    anim.SetTrigger("Punch");
                    enemyHealth.TakeDamage(10); // Damage the enemy if 
                }
                else if (animationType == AnimationType.BlockAnimation)
                {
                    anim.SetTrigger("Shield");
                }
                // Optionally, wait for animation to finish before destroying
                Destroy(gameObject); // Remove the bubble
                anim.SetTrigger("Default");
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
