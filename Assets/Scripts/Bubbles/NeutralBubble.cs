using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class NeutralBubble : MonoBehaviour, IBubble
    {
        public void OnInteract()
        {
            print("Neutral Bubble");
        }
    }
}