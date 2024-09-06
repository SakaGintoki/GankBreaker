using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] TextMeshProUGUI HealthNote;
    [SerializeField] Image EscapeButtonImage;
    [SerializeField] int PlatformerIndex = 4;
    private int countClickRetreat = 0;
    private string sceneToLoad;


    void Awake()
    {
        sceneToLoad = "Platformer";
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
        HealthNote.SetText("");
    }

    void Escape()
    {
        if (countClickRetreat == 0)
        {
            float randomValue = UnityEngine.Random.value;
            if (randomValue < 0.6f)
            {
                SceneManager.LoadScene(PlatformerIndex);
            }
            else
            {
                EscapeButtonImage.color = Color.red;
            }
            countClickRetreat++;
        }
        else
        {
            
        }
    }
}
