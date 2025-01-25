using Interfaces;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class KillerBubble : MonoBehaviour, IBubble
    {
        private void Start()
        {
            gameObject.tag = "Enemy";
        }

        public void OnInteract()
        {
            BubbleEvents.OnKill();
            Destroy(this);
        }
    }
}