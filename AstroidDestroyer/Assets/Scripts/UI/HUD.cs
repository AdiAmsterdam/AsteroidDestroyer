using System;
using System.Collections.Generic;
using Player;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private BatteryUI batteryUI;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI controlsText;
    private string controls = "Controls:\n" +
                              "W - Acceleration\n" +
                              "A/D - Rotate\n" +
                              "SHIFT - Dash\n" +
                              "SPACE - Shoot Gun\n" +
                              "CTRL - Toggle Laser Sword\n" +
                              "\n" +
                              "PRESS I TO CLOSE";

    private string controlsOff = "PRESS I TO OPEN CONTROLS";
    
    [SerializeField] private EnergySystem energySystem;
    [SerializeField] private Image energyBarImage;
    [SerializeField] private Image energyAmount;

    private void Awake()
    {
        controlsText.text = controlsOff;
    }

    void Update()
    {
        UpdateEnergy(energySystem.GetEnergyPercentage());

        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            if (controlsText.text == controls)
            {
                controlsText.text = controlsOff;
            }
            else controlsText.text = controls;
        }
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