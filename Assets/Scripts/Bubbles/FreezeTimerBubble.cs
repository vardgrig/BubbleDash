using Interfaces;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class FreezeTimerBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float duration;
        private bool _isFrozen;
        public void OnInteract()
        {
            if (_isFrozen) return;
            _isFrozen = true;
            BubbleEvents.OnFreezeTimer(duration);
            Destroy(this);
        }
    }
}