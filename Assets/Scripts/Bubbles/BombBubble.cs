using System.Collections;
using Character;
using Interfaces;
using UnityEngine;

namespace Bubbles
{
    public class BombBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float timeToDestroy = 2f;
        private bool _isActive = false;
        public void OnInteract(CharacterMovement characterMovement)
        {
            if (_isActive) 
                return;
            _isActive = true;
            StartCoroutine(DestroyBubble());
        }

        private IEnumerator DestroyBubble()
        {
            yield return new WaitForSeconds(timeToDestroy);
            BubbleEvents.OnExplode(timeToDestroy, transform.position);
            Destroy(this);
        }
    }
}