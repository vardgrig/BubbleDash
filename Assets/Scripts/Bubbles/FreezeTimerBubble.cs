using Interfaces;
using SoundSystem;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class FreezeTimerBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float duration;
        [SerializeField] private string soundName;
        private bool _isFrozen;
        public void OnInteract()
        {
            if (_isFrozen) return;
            _isFrozen = true;
            AudioManager.instance.Play(soundName);
            BubbleEvents.OnFreezeTimer(duration);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
    }
}