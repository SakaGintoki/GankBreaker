using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonFightHandler : MonoBehaviour
{
    [SerializeField] GameObject ChoicePanel;
    [SerializeField] Button FightButton;
    [SerializeField] Button EscapeButton;
    [SerializeField] GameObject BubbleSpawner;
    [SerializeField] GameObject EnemyHealthSlider;
    [SerializeField] GameObject HealthSlider;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
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

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
