using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health Bar")]
    [SerializeField] Slider healthBar;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<Score>();
    }

    void Start()
    {
        healthBar.maxValue = playerHealth.GetHealth();
    }

    
    void Update()
    {
        healthBar.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
