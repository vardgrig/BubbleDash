using System.Collections;
using DG.Tweening;
using General;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Character
{
    public class CharacterDeath :MonoBehaviour
    {
        [SerializeField] private CanvasGroup faderGroup;
        [SerializeField] private string levelName;
        [SerializeField] private float fadeDuration;

        private void OnEnable()
        {
            CharacterEvents.Dead += OnDead;
        }

        private void OnDisable()
        {
            CharacterEvents.Dead -= OnDead;
        }
        
        private void OnDead()
        {
            faderGroup.DOFade(1, fadeDuration);
            StartCoroutine(SceneLoader.LoadSceneAsync(levelName, fadeDuration));
        }
    }
}