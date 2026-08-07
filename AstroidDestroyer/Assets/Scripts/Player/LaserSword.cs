using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;
using VolumetricLines;

namespace Player
{
    public class LaserSword : MonoBehaviour
    {
        [SerializeField] private VolumetricLineBehavior laserSword;
        
        private Health fullBatteries;
        
        private EnergySystem energySystem;
        private float swordOpenEnergySpent = 15f;
        private float swordActiveEnergySpent = 7f;
        
        private Coroutine swordRoutine;

        private SwordState swordState;

        [SerializeField] private AudioClip startSound;
        [SerializeField] private AudioClip swordHumLoop;
        [SerializeField] private AudioClip closeSound;
        //recharge = plays when recharging???
        
        private float laserRange = 150f;
        private float maxRange;
        private float extendSpeed;
        private float currentLength;
        
        [SerializeField] private BoxCollider2D SwordCollider;
        private float colliderWidth = 3.45f;

        private void Awake()
        {
            fullBatteries = GetComponentInParent<Health>();
            swordState = SwordState.Closed;
            SwordCollider.enabled = false;
            energySystem = GetComponentInParent<EnergySystem>();
        }

        void Update()
        {
            if (swordState == SwordState.Open || swordState == SwordState.Opening)
            {
                if (!energySystem.TrySpendEnergy(swordActiveEnergySpent * Time.deltaTime))
                {
                    if(swordRoutine == null) swordRoutine = StartCoroutine(CloseLaserSword());
                }
            }
            if (Keyboard.current.ctrlKey.wasPressedThisFrame)
            {
                if (swordRoutine != null)
                {
                    StopCoroutine(swordRoutine);
                    swordRoutine = null;
                }
                
                switch (swordState)
                {
                    case SwordState.Closed:
                        if(energySystem.TrySpendEnergy(swordOpenEnergySpent))
                            swordRoutine = StartCoroutine(OpenLaserSword());
                        break;
                    case SwordState.Opening:
                        swordRoutine = StartCoroutine(CloseLaserSword());
                        break;
                    case SwordState.Open:
                        swordRoutine = StartCoroutine(CloseLaserSword());
                        break;
                    case SwordState.Closing:
                        swordRoutine = StartCoroutine(OpenLaserSword());
                        break;
                }
            }
        }

        private IEnumerator OpenLaserSword()
        {
            swordState = SwordState.Opening;
            maxRange = laserRange * fullBatteries.GetActiveBatteryAmount();
            AudioManager.audioManager.PlaySFX(AudioChannel.LaserSword, startSound);
            extendSpeed = maxRange / startSound.length;
            laserSword.enabled = true;
            while (currentLength < maxRange)
            {
                currentLength = Mathf.MoveTowards(currentLength, maxRange, extendSpeed * Time.deltaTime);
                laserSword.StartPos = Vector3.up * currentLength;
                UpdateSwordCollider();
                yield return null;
            }
            swordState = SwordState.Open;
            SwordCollider.enabled = true;
            AudioManager.audioManager.PlayLaserSwordLoop(swordHumLoop);
        }

        private IEnumerator CloseLaserSword()
        {
            swordState = SwordState.Closing;
            AudioManager.audioManager.StopLaserSwordLoop();
            AudioManager.audioManager.PlaySFX(AudioChannel.LaserSword, closeSound);
            SwordCollider.enabled = false;
            extendSpeed = maxRange / closeSound.length;
            while (currentLength > 0f)
            {
                currentLength = Mathf.MoveTowards(currentLength, 0f, extendSpeed * Time.deltaTime);
                laserSword.StartPos = Vector3.up * currentLength;
                UpdateSwordCollider();
                yield return null;
            }
            laserSword.StartPos = Vector3.zero;
            laserSword.enabled = false;
            swordState = SwordState.Closed;
        }
        
        private void UpdateSwordCollider()
        {
            SwordCollider.size = new Vector2(colliderWidth, currentLength);
            SwordCollider.offset = new Vector2(0, currentLength / 2);
        }
    }
}