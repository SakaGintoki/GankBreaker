using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public UnityEvent OnDead;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int damage = 10;
    public int currentHealth;
    public Slider EnemyHealthSlider;
    private static int EnemyDeath = 0;
    private static int FPS1Count = 0;
    private static int FPS2Count = 0;
    private static int FPS3Count = 0;
    private MainCharacterHealth healthMC = new MainCharacterHealth();
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
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "FPS1")
        {
            if (FPS1Count < 1)
            {
                EnemyDeath++;
            }
        }
        else if (sceneName == "FPS2")
        {
            if (FPS2Count < 1)
            {
                EnemyDeath++;
            }
        }
        else if (sceneName == "FPS3")
        {
            if (FPS3Count < 1)
            {
                EnemyDeath++;
            }
        }
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
        increaseMCHealthAndDamage();
        // Logic when the enemy dies
        mcAnimation.SetAnimationDefault();
        enemyAnimation.SetAnimationDefault();
        Debug.Log("Enemy Defeated");
        OnDead.Invoke();
        // Optionally, trigger other game events here, like stopping the game or showing a victory screen.
        BubbleSpawner spawner = FindObjectOfType<BubbleSpawner>();
        spawner.StopSpawning();  // Stop spawning bubbles when the enemy is defeated
        if (EnemyDeath == 3) 
        {
            SceneManager.LoadScene("Prolog");
        }
        else
        {
            SceneManager.LoadScene("Platformer");
        }
    }

    void increaseMCHealthAndDamage()
    {
        MainCharacterHealth.maxHealth += 10;
        MainCharacterHealth.damage += 10;
    }
}
