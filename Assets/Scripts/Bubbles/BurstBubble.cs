using Interfaces;
using SoundSystem;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class BurstBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float range;
        [SerializeField] private string soundName;

        public void OnInteract()
        {
            BubbleEvents.OnBurst(range);
            AudioManager.instance.Play(soundName);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
    }
}