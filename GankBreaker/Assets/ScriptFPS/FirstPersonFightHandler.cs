using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstPersonFightHandler : MonoBehaviour
{
    [SerializeField] GameObject ChoicePanel;
    [SerializeField] Button FightButton;
    [SerializeField] Button EscapeButton;
    [SerializeField] GameObject BubbleSpawner;
    [SerializeField] GameObject EnemyHealthSlider;
    [SerializeField] GameObject HealthSlider;
    private string sceneToLoad;


    void Awake()
    {
        sceneToLoad = "Platformer";
        SceneManager.LoadScene(sceneToLoad);
        ChoicePanel.SetActive(true);
        FightButton.onClick.AddListener(Fight);
        EscapeButton.onClick.AddListener(Escape);
        BubbleSpawner.SetActive(false);
        EnemyHealthSlider.SetActive(false);
        HealthSlider.SetActive(false);
    }

    void Fight()
    {
        ChoicePanel.SetActive(false);
        BubbleSpawner?.SetActive(true);
        EnemyHealthSlider.SetActive(true);
        HealthSlider.SetActive(true);
    }

    void Escape()
    {
        float randomValue = UnityEngine.Random.value;
        if (randomValue < 0.6f)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            
        }
    }
}
