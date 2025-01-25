using Interfaces;
using SoundSystem;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class InvertBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float duration;
        [SerializeField] private string soundName;
        
        private void Start()
        {
            gameObject.tag = "Enemy";
        }

        public void OnInteract()
        {
            BubbleEvents.OnInvert(duration);
            AudioManager.instance.Play(soundName);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
    }
}