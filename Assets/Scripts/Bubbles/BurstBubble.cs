using Interfaces;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class BurstBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float range;
        public void OnInteract()
        {
            BubbleEvents.OnBurst(range);
            Destroy(this);
        }
    }
}