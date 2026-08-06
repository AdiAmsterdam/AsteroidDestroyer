using System;
using System.Collections.Generic;
using Player;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private BatteryUI batteryUI;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [SerializeField] private EnergySystem energySystem;
    [SerializeField] private Image energyBarImage;
    [SerializeField] private Image energyAmount;
    
    void Update()
    {
        UpdateEnergy(energySystem.GetEnergyPercentage());
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateHealth(List<int> batteries)
    {
        batteryUI.UpdateBatteryUI(batteries);
    }

    private void UpdateEnergy(float precent)
    {
        energyAmount.fillAmount = precent;
    }
}