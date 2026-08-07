using System;
using UnityEngine;

namespace Player
{
    public class EnergySystem : MonoBehaviour
    {
        [SerializeField] private float maxEnergy = 100f;
        [SerializeField] private float rechargeSpeed = 5f;
        private float currentEnergy;
        public bool isOverheating { get; private set;}
       

        void Awake()
        {
            currentEnergy = maxEnergy;
            isOverheating = false;
        }

        void Update()
        {
            if (currentEnergy >= maxEnergy) currentEnergy = maxEnergy;
            UpdateEnergy();
        }

        public bool TrySpendEnergy(float amount)
        {
            if (isOverheating) return false;
            if (currentEnergy <= 0)
            {
                isOverheating = true;
                return false;
            }
            if (amount >= currentEnergy)
            {
                currentEnergy = 0;
                isOverheating = true;
                return true;
            }
            currentEnergy -= amount;
            return true;
        }

        private void UpdateEnergy()
        {
            if (isOverheating)
            {
                currentEnergy = Mathf.Clamp(currentEnergy + Mathf.Pow(rechargeSpeed, 2) * Time.deltaTime, 0f,
                    maxEnergy);
                if (currentEnergy >= maxEnergy) isOverheating = false;
            }
            else currentEnergy = Mathf.Clamp(currentEnergy + rechargeSpeed * Time.deltaTime, 0f, maxEnergy);
            
        }

        public float GetEnergyPercentage()
        {
            return currentEnergy / maxEnergy;
        }
    }
}