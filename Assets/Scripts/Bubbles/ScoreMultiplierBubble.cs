using Character;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class ScoreMultiplierBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float multiplier = 2f;
        
        public void OnInteract(CharacterMovement characterMovement)
        {
            // multiply score
        }
    }
}