using Character;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class AddTimerBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float secondsToAdd = 1f;
        
        public void OnInteract(CharacterMovement characterMovement)
        {
            BubbleEvents.OnTimerChange(secondsToAdd);
            Destroy(this);
        }
    }
}