using Interfaces;
using UnityEngine;
using SoundSystem;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class AddTimerBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float secondsToAdd = 1f;
        [SerializeField] private string soundName;
        
        public void OnInteract()
        {
            BubbleEvents.OnTimerChange(secondsToAdd);
            AudioManager.instance.Play(soundName);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
    }
}