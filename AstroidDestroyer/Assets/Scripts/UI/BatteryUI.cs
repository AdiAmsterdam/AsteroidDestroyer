using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BatteryUI :  MonoBehaviour
    {
        [SerializeField] private Image[] batteryImages = new Image[3];
        [SerializeField] private Sprite[] batterySprites = new Sprite[5];
        
        public void UpdateBatteryUI(List<int> batteries)
        {
            for (int i = 0; i < batteries.Count; i++)
            {
                batteryImages[i].sprite = batterySprites[batteries[i]];
            }
        }
    }
}