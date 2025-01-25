using System;
using System.Collections;
using Bubbles;
using DG.Tweening;
using UnityEngine;

namespace Character
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity = 100f;
        [SerializeField] private float dashFov = 75f;
        private bool _isInverted;
        private float _xRotation = 0f;
        private float _yRotation = 0f;

        private float _originalFov;
        private Camera _cam;

        private void OnEnable()
        {
            BubbleEvents.Invert += Invert;
            CharacterEvents.Dash += Dash;
        }

        private void OnDisable()
        {
            BubbleEvents.Invert -= Invert;
            CharacterEvents.Dash -= Dash;
        }

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            _cam = Camera.main;
            _originalFov = _cam.fieldOfView;
        }
        
        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            mouseX = _isInverted ? -mouseX : mouseX;
            mouseY = _isInverted ? -mouseY : mouseY;

            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            
            transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        }

        #region DashEffect
        private void Dash(bool isDashing)
        {
            ChangeFov(isDashing ? dashFov : _originalFov);
        }

        private void ChangeFov(float fov)
        {
            _cam.DOFieldOfView(fov, 0.25f);
        }
        #endregion
        
        #region Invert
        private void Invert(float duration)
        {
            StartCoroutine(InvertControls(duration));
        }

        private IEnumerator InvertControls(float duration)
        {
            _isInverted = true;
            yield return new WaitForSeconds(duration);
            _isInverted = false;
        }
        #endregion

    }
}