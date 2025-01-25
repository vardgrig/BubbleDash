using Character;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class FreezeTimerBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float duration;
        private bool _isFrozen;
        public void OnInteract(CharacterMovement characterMovement)
        {
            if (_isFrozen) return;
            _isFrozen = true;
            BubbleEvents.OnFreezeTimer(duration);
            Destroy(this);
        }
    }
}