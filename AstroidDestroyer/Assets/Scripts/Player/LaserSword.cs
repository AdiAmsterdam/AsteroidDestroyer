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
        
        private ShipMovement shipMovement;
        private EnergySystem energySystem;
        
        private Coroutine swordRoutine;

        private SwordState swordState;

        [SerializeField] private float EnergyDrain = 15f;

        [SerializeField] private AudioClip startSound;
        [SerializeField] private AudioClip swordHumLoop;
        [SerializeField] private AudioClip closeSound;
        //recharge = plays when recharging???
        
        [SerializeField] private float laserRange = 200f;
        private float extendSpeed; //will be at the same rate as the start sound/ end sound
        private float currentLength;
        
        [SerializeField] private BoxCollider2D SwordCollider;
        private float colliderWidth = 3.45f;

        private void Awake()
        {
            swordState = SwordState.Closed;
            SwordCollider.enabled = false;
            energySystem = GetComponentInParent<EnergySystem>();
            shipMovement = GetComponentInParent<ShipMovement>();
        }

        void Update()
        {
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
            AudioManager.audioManager.PlaySFX(AudioChannel.LaserSword, startSound);
            extendSpeed = laserRange / startSound.length;
            laserSword.enabled = true;
            while (currentLength < laserRange)
            {
                currentLength = Mathf.MoveTowards(currentLength, laserRange, extendSpeed * Time.deltaTime);
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
            extendSpeed = laserRange / closeSound.length;
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