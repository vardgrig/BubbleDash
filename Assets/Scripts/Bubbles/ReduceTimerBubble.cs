using Character;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class ReduceTimerBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float secondsToReduce;

        public void OnInteract(CharacterMovement characterMovement)
        {
            BubbleEvents.OnTimerChange(secondsToReduce);
        }
    }
}