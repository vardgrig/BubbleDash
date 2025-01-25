using Interfaces;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class InvertBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float duration;
        
        private void Start()
        {
            gameObject.tag = "Enemy";
        }

        public void OnInteract()
        {
            BubbleEvents.OnInvert(duration);
            Destroy(this);
        }
    }
}