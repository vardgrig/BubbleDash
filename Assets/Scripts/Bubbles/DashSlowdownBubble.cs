using Character;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class DashSlowdownBubble : MonoBehaviour, IBubble
    {
        [SerializeField] public float distanceToRemove = 10f;
        [SerializeField] public float speedMultiplier = 0.5f;
        public void OnInteract(CharacterMovement characterMovement)
        {
            //change speed and distance
        }
    }
}