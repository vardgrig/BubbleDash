using System;
using Character;
using SoundSystem;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Animator))]
    public class FinishUI : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string finishParameter;
        [SerializeField] private string finishSoundName;
        private void OnEnable()
        {
            CharacterEvents.Finish += OnFinished;
        }

        private void OnDisable()
        {
            CharacterEvents.Finish -= OnFinished;
        }
        
        private void OnFinished()
        {
            animator.SetTrigger(finishParameter);
            AudioManager.instance.Play(finishSoundName);
        }
    }
}