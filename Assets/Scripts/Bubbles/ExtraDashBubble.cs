using Interfaces;
using SoundSystem;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class ExtraDashBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private string soundName;

        public void OnInteract()
        {
            BubbleEvents.OnExtraDash();
            AudioManager.instance.Play(soundName);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
    }
}