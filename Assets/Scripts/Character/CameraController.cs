using System;
using System.Collections;
using Bubbles;
using UnityEngine;

namespace Character
{
    public class CameraController : MonoBehaviour
    {
        public float mouseSensitivity = 100f;
        //public Transform playerBody;
        private bool _isInverted;

        private float _xRotation = 0f;
        
        private float _yRotation = 0f;

        private void OnEnable()
        {
            BubbleEvents.Invert += Invert;
        }

        private void OnDisable()
        {
            BubbleEvents.Invert -= Invert;
        }

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
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
    }
}