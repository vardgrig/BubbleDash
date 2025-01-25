using System.Collections;
using Interfaces;
using SoundSystem;
using UnityEngine;

namespace Bubbles
{
    [DisallowMultipleComponent]
    public class BombBubble : MonoBehaviour, IBubble
    {
        [SerializeField] private float timeToDestroy = 2f;
        [SerializeField] private float range = 10f;
        [SerializeField] private string soundName;
        private bool _isActive;

        private void Start()
        {
            gameObject.tag = "Enemy";
        }
            
        public void OnInteract()
        {
            if (_isActive) 
                return;
            _isActive = true;
            AudioManager.instance.Play(soundName);
            StartCoroutine(DestroyBubble());
        }

        private IEnumerator DestroyBubble()
        {
            yield return new WaitForSeconds(timeToDestroy);
            BubbleEvents.OnExplode(range, transform.position);
            Destroy(this);
        }
    }
}