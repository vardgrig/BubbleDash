using System;
using Character;
using UnityEngine;
using SoundSystem;

namespace Portal
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private GameObject effect;
        [SerializeField] private string soundName;

        private void OnEnable()
        {
            CharacterEvents.Winnable += OnFinished;
        }

        private void OnDisable()
        {
            CharacterEvents.Winnable -= OnFinished;
        }

        private void OnFinished()
        {
            effect.SetActive(true);
            AudioManager.instance.Play(soundName);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CharacterEvents.OnWinnable();
            }
        }
    }
}