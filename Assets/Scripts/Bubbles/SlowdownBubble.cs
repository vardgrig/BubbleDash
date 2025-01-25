using Interfaces;
using SoundSystem;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class SlowdownBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float duration;
        [SerializeField] [Range(0,1)] private float speedMultiplier;
        [SerializeField] [Range(0,1)] private float distanceMultiplier;
        [SerializeField] private string soundName;

        private void Start()
        {
            gameObject.tag = "Enemy";
        }

        public void OnInteract()
        {
            BubbleEvents.OnSlowdown(duration, speedMultiplier, distanceMultiplier);
            AudioManager.instance.Play(soundName);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
    }
}