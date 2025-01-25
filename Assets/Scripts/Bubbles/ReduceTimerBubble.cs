using Interfaces;
using SoundSystem;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class ReduceTimerBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float secondsToReduce;
        [SerializeField] private string soundName;
                
        private void Start()
        {
            gameObject.tag = "Enemy";
        }

        public void OnInteract()
        {
            BubbleEvents.OnTimerChange(secondsToReduce);
            AudioManager.instance.Play(soundName);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
    }
}