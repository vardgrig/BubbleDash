using Character;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class ExtraDashBubble : MonoBehaviour, IBubble
    {
        public void OnInteract(CharacterMovement characterMovement)
        {
            BubbleEvents.OnExtraDash();
            Destroy(this);
        }
    }
}