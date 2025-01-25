using Interfaces;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class ReduceTimerBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float secondsToReduce;

                
        private void Start()
        {
            gameObject.tag = "Enemy";
        }

        public void OnInteract()
        {
            BubbleEvents.OnTimerChange(secondsToReduce);
            Destroy(this);
        }
    }
}