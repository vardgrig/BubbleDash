using Character;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class InvertBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float duration;
        public void OnInteract(CharacterMovement characterMovement)
        {
            BubbleEvents.OnInvert(duration);
            Destroy(this);
        }
    }
}