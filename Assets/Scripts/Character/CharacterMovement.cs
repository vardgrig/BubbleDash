using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bubbles;
using Interfaces;
using PortalSystem;
using UI;
using UnityEngine;
namespace Character
{
    public class CharacterMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float timer = 60f;
        [SerializeField] private float dashSpeed = 10f;
        [SerializeField] private float dashDuration = 1f;

        private bool _isDashing;
        private bool _isFreezeTime;
        private bool _isInBubble;
        private float _dashTime;
        private Vector3 _dashDirection;
        private GameObject _bubble;
        private bool _canWin;

        private int _starsCount = 0;
        private const int STARS_TO_COLLECT = 10;
        
        private Rigidbody _rigidbody;
        private Camera _cam;
        private int _previousTimerInt;

        #endregion

        #region EventListeners
        private void OnEnable()
        {
            BubbleEvents.Kill += OnKillCharacter;
            BubbleEvents.TimerChange += OnChangeTimer;
            BubbleEvents.FreezeTimer += OnFreezeTimer;
            BubbleEvents.Explode += OnExplode;
            BubbleEvents.CollectStar += OnCollectStar;
        }

        private void OnDisable()
        {
            BubbleEvents.Kill -= OnKillCharacter;
            BubbleEvents.TimerChange -= OnChangeTimer;
            BubbleEvents.FreezeTimer -= OnFreezeTimer;
            BubbleEvents.Explode -= OnExplode;
            BubbleEvents.CollectStar -= OnCollectStar;
        }
        #endregion

        #region UnityFunctions
        private void Start()
        {
            _cam = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();
            _previousTimerInt = Mathf.FloorToInt(timer);
        }

        private void Update()
        {
            DashingAndAbilities();
            TimerUpdates();
        }

        private void TimerUpdates()
        {
            if (!_isFreezeTime)
            {
                timer -= Time.deltaTime;
                var currentTimerInt = Mathf.FloorToInt(timer);
                if (currentTimerInt != _previousTimerInt)
                {
                    UIEvents.OnTimerUpdate(currentTimerInt);
                    _previousTimerInt = currentTimerInt;
                }
            }

            if (timer < 0)
            {
                timer = 0;
                UIEvents.OnTimerUpdate(0);
                OnKillCharacter();
                _isFreezeTime = true;
            }
        }
        private void DashingAndAbilities()
        {
            if (Input.GetMouseButtonDown(0) && !_isDashing)
            {
                StartDash();
            }
            if (_isDashing)
            {
                ContinueDash();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            print("Trigger");
            if (other.TryGetComponent(out IBubble bubble))
            {
                _bubble = other.gameObject;
                CharacterEvents.OnBubbleEnter(bubble);
                bubble.OnInteract();
            }
            else if (other.TryGetComponent(out Portal portal))
            {
                if(_canWin)
                    CharacterEvents.OnFinish();
            }
            StopDash();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out StarBubble bubble))
            {
                Destroy(bubble.gameObject);
            }
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
                StopDash();
            }
        }

        private void StartDash()
        {
            CharacterEvents.OnDash(true);
            
            _dashDirection = _cam.transform.forward.normalized;
            _isDashing = true;
            _dashTime = dashDuration;
            
            if (_bubble == null) 
                return;
            
            CharacterEvents.OnBubbleExit();
            _bubble.GetComponent<Collider>().enabled = false;
            _rigidbody.isKinematic = false;
            _bubble = null;
        }

        private void StopDash()
        {
            CharacterEvents.OnDash(false);
            _isDashing = false;
            if (_bubble)
            {
                _rigidbody.isKinematic = true;
            }
        }

        #endregion

        #region EventHandlers
        private void OnChangeTimer(float seconds)
        {
            timer += seconds;
            UIEvents.OnTimerUpdate((int)timer);
        }

        private void OnKillCharacter()
        {
            _rigidbody.isKinematic = true;
            CharacterEvents.OnDead();
        }

        private void OnFreezeTimer(float seconds)
        {
            StartCoroutine(FreezeTimer(seconds));
        }
        
        private void OnExplode(float range, Vector3 pos)
        {
            if (Vector3.Distance(transform.position, pos) <= range)
            {
                OnKillCharacter();
            }
        }
        private void OnCollectStar()
        {
            _starsCount += 1;
            UIEvents.OnStarUpdate(_starsCount, STARS_TO_COLLECT);
            if (_starsCount != STARS_TO_COLLECT)
                return;
            CharacterEvents.OnWinnable();
            _canWin = true;
        }
        #endregion

        #region Abilities
        private IEnumerator FreezeTimer(float duration)
        {
            _isFreezeTime = true;
            yield return new WaitForSeconds(duration);
            _isFreezeTime = false;
        }
        #endregion
    }
}