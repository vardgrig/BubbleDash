using Interfaces;
using SoundSystem;
using UnityEngine;

namespace Bubbles
{
    public class StarBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private string soundName;

        public void OnInteract()
        {
            BubbleEvents.OnCollectStar();
            AudioManager.instance.Play(soundName);
            transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
    }
}