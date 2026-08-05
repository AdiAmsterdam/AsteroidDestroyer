using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BatteryUI
    {
        public Image activeImage;
        [SerializeField] private Sprite[] BatterySprites;

        public int charge { get; private set; } = 4;
    }
}