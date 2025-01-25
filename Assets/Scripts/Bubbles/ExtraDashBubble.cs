using Interfaces;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class ExtraDashBubble : MonoBehaviour, IBubble
    {
        public void OnInteract()
        {
            BubbleEvents.OnExtraDash();
            Destroy(this);
        }
    }
}