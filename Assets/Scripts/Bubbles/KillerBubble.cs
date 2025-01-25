using Character;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class KillerBubble : MonoBehaviour, IBubble
    {
        public void OnInteract(CharacterMovement characterMovement)
        {
            BubbleEvents.OnKill();
            Destroy(this);
        }
    }
}