using System;
using System.Collections.Generic;
using Player;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    private int imageSize = 100;
    private List<BatteryUI> batteryUI;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [SerializeField] private EnergySystem energySystem;
    [SerializeField] private Image energyBarImage;
    [SerializeField] private Image energyAmount;
    

    private void Awake()
    {
        batteryUI = new List<BatteryUI>(3);
    }

    void Update()
    {
        UpdateEnergy(energySystem.GetEnergyPercentage());
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateHealth(int amount)
    {
        healthImage.rectTransform.sizeDelta = new Vector2(imageSize * amount, imageSize);
    }

    private void UpdateEnergy(float precent)
    {
        energyAmount.fillAmount = precent;
    }
}