using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BatteryUI
    {
        [SerializeField] private Image image;
        [SerializeField] private Sprite[] BatterySprites;

        public int charge { get; private set; } = 4;
    }
}