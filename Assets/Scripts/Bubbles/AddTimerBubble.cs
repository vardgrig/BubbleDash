using Interfaces;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class AddTimerBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float secondsToAdd = 1f;
        
        public void OnInteract()
        {
            BubbleEvents.OnTimerChange(secondsToAdd);
            Destroy(this);
        }
    }
}