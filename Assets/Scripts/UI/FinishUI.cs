using System;
using Character;
using DG.Tweening;
using SoundSystem;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(Animator))]
    public class FinishUI : MonoBehaviour
    {
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private CanvasGroup faderGroup;
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
            if(!string.IsNullOrEmpty(finishSoundName))
                AudioManager.instance.Play(finishSoundName);
            CharacterEvents.OnWin(fadeDuration);
            faderGroup.DOFade(1, fadeDuration);
        }
    }
}