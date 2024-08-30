using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Text bubbleText;
    [SerializeField] private char bubbleKey;
    [SerializeField] private float lifeTime = 1f; 
    [SerializeField] private string firstPersonHandTag = "FirstPersonHand";
    [SerializeField] private Color PunchColor;
    [SerializeField] private Color ShieldColor;
    [SerializeField] private Color BubbleColor;

    private float timer;
    private bool keyPressed = false;
    private MCAnimation mcAnimation;
    private EnemyAnimation enemyAnimation;

    private MainCharacterHealth playerHealth;
    private EnemyHealth enemyHealth;

    private enum AnimationType { BlockAnimation, PunchAnimation }
    private AnimationType animationType;

    void Start()
    {
        // bubbleKey = (char)('A' + UnityEngine.Random.Range(0, 26));
        bubbleText.text = "";

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
            bubbleText.color = Color.white;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        float randomValueShieldEnemy = UnityEngine.Random.value;
        
        if (Input.anyKeyDown && !keyPressed)
        {
            if (Input.GetKeyDown(bubbleKey.ToString().ToLower()) || Input.GetKeyDown(bubbleKey.ToString().ToUpper()))
            {
                keyPressed = true; 
                if (animationType == AnimationType.PunchAnimation && enemyHealth != null)
                {
                    mcAnimation.SetAnimationPunch();
                    if (randomValueShieldEnemy <= 0.5f)
                    {
                        enemyAnimation.SetAnimationShield();
                    } 
                    else
                    {
                        enemyHealth.TakeDamage(10); 
                    }
                    enemyAnimation.SetAnimationDefault();
                }
                else if (animationType == AnimationType.BlockAnimation)
                {
                    enemyAnimation.SetAnimationPunch();
                    mcAnimation.SetAnimationShield();
                }
                Destroy(gameObject); // Remove the bubble
                mcAnimation.SetAnimationDefault();
                enemyAnimation.SetAnimationDefault();
            }
            else if (playerHealth != null)
            {
                enemyAnimation.SetAnimationPunch();
                playerHealth.TakeDamage(enemyHealth.damage); // Decrease health if wrong key pressed
                Destroy(gameObject); // Remove the bubble
            }
             enemyAnimation.SetAnimationDefault();
        }

        // Check if the time is up
        if (timer >= lifeTime && !keyPressed)
        {
            if (playerHealth != null)
            {
                enemyAnimation.SetAnimationPunch();
                playerHealth.TakeDamage(10); // Decrease health if time runs out
            }
            Destroy(gameObject); // Remove the bubble
            enemyAnimation.SetAnimationDefault();
        }

        enemyAnimation.SetAnimationDefault();
        mcAnimation.SetAnimationDefault();
    }
}
