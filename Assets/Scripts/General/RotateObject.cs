using System;
using UnityEngine;

namespace General
{
    public class RotateObject : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationAxis;
        [SerializeField] private float rotationSpeed;

        private void Update()
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        }
    }
}