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
    [SerializeField] Image EscapeButtonImage;
    private int countClickRetreat = 0;
    private string sceneToLoad;


    void Awake()
    {
        sceneToLoad = "Platformer";
        ChoicePanel.SetActive(true);
        FightButton.onClick.AddListener(Fight);
        if (countClickRetreat < 1)
        {
            EscapeButton.onClick.AddListener(Escape);
            countClickRetreat++;
        }
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
            SceneManager.LoadScene(1);
        }
        else
        {
            EscapeButtonImage.color = Color.red;
        }
    }
}
