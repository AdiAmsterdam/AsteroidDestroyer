using System;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    private int imageSize = 100;
    [SerializeField] private TextMeshProUGUI scoreText;
    private List<BatteryUI> batteryUI;

    private void Awake()
    {
        batteryUI = new List<BatteryUI>(3);
    }

    void Update()
    {
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateHealth(int amount)
    {
        healthImage.rectTransform.sizeDelta = new Vector2(imageSize * amount, imageSize);
    }
}