using Interfaces;
using SoundSystem;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class KillerBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private string soundName;

        private void Start()
        {
            gameObject.tag = "Enemy";
        }

        public void OnInteract()
        {
            BubbleEvents.OnKill();
            AudioManager.instance.Play(soundName);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
    }
}