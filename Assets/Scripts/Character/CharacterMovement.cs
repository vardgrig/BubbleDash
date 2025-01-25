using System;
using System.Collections;
using System.Collections.Generic;
using Bubbles;
using Interfaces;
using UnityEngine;

namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float timer = 60f;
        [SerializeField] private float dashSpeed = 10f;
        [SerializeField] private float dashDuration = 1f;


        private List<KeyValuePair<Abilities, float>> _abilities = new();
        private bool _isDashing;
        private bool _isFreezeTime;
        private bool _isInBubble;
        private float _dashTime;
        private Vector3 _dashDirection;
        private GameObject _bubble;
        
        private Rigidbody _rigidbody;
        private Camera _cam;

        #endregion

        #region EventListeners
        private void OnEnable()
        {
            BubbleEvents.Kill += OnKillCharacter;
            BubbleEvents.TimerChange += OnChangeTimer;
            BubbleEvents.ExtraDash += OnAddExtraDash;
            BubbleEvents.FreezeTimer += OnFreezeTimer;
            BubbleEvents.Explode += OnExplode;
        }
        
        private void OnDisable()
        {
            BubbleEvents.Kill -= OnKillCharacter;
            BubbleEvents.TimerChange -= OnChangeTimer;
            BubbleEvents.ExtraDash -= OnAddExtraDash;
            BubbleEvents.FreezeTimer -= OnFreezeTimer;
            BubbleEvents.Explode -= OnExplode;
        }
        #endregion

        #region UnityFunctions
        private void Start()
        {
            _cam = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_isDashing)
            {
                StartDash();
            }
            else if (Input.GetMouseButtonDown(1) && _abilities.Count > 0)
            {
                ActivateAbility();
            }

            if (_isDashing)
            {
                ContinueDash();
            }

            if (!_isFreezeTime)
            {
                timer -= Time.deltaTime;
            }

            if (timer < 0)
            {
                OnKillCharacter();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            print("Trigger");
            _bubble = other.gameObject;
            _bubble?.GetComponent<IBubble>()?.OnInteract(this);
            _rigidbody.isKinematic = true;
            StopDash(); //TODO: implement stopping mechanism
        }

        private void OnTriggerExit(Collider other)
        {
            _rigidbody.isKinematic = false;
        }

        #endregion

        #region DashMechanism

        private void ContinueDash()
        {
            if (_dashTime > 0)
            {
                transform.Translate(_dashDirection * (dashSpeed * Time.deltaTime));
                _dashTime -= Time.deltaTime;
            }
            else
            {
                _isDashing = false;
            }
        }

        private void StartDash()
        {
            _dashDirection = _cam.transform.forward.normalized;
            _isDashing = true;
            _dashTime = dashDuration;
            
            if (_bubble == null) 
                return;
            
            _rigidbody.isKinematic = false;
            _bubble.GetComponent<Collider>().enabled = false;
            _bubble = null;
        }

        private void StopDash()
        {
            _isDashing = false; //stop mechanism
        }

        #endregion

        #region EventHandlers

        private void OnAddExtraDash()
        {
            var ability = new KeyValuePair<Abilities, float>(Abilities.ExtraDash, 1);
            _abilities.Add(ability);
        }

        private void OnChangeTimer(float seconds)
        {
            timer += seconds;
        }

        private void OnKillCharacter()
        {
            // TODO: kill the character
            print("Character is dead!");
        }

        private void OnFreezeTimer(float obj)
        {
            var ability = new KeyValuePair<Abilities, float>(Abilities.FreezeTime, obj);
            _abilities.Add(ability);
        }
        
        private void OnExplode(float obj, Vector3 pos)
        {
            if (Vector3.Distance(transform.position, pos) <= 10)
            {
                OnKillCharacter();
            }
        }

        #endregion

        #region Abilities
        private void ActivateAbility()
        {
            switch (_abilities[^1].Key)
            {
                case Abilities.ExtraDash:
                    ExtraDash();
                    break;
                case Abilities.Burst:
                    break;
                case Abilities.FreezeTime:
                    StartCoroutine(FreezeTimer(_abilities[^1].Value));
                    break;
            }
        }

        private void ExtraDash()
        {
            // TODO: Extra Dash functionality
            StartDash();
        }

        private IEnumerator FreezeTimer(float duration)
        {
            _isFreezeTime = true;
            yield return new WaitForSeconds(duration);
            _isFreezeTime = false;
        }

        #endregion
    }
}