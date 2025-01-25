using System;
using Character;
using UnityEngine;
using SoundSystem;

namespace PortalSystem
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
    }
}