using System.Collections;
using General;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    public class CharacterDeath :MonoBehaviour
    {
        [SerializeField] private GameObject deathEffect;
        [SerializeField] private string levelName;
        [SerializeField] private float effectDuration;

        private void Start()
        {
            deathEffect.SetActive(false);
        }

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
            deathEffect.SetActive(true);
            StartCoroutine(SceneLoader.LoadSceneAsync(levelName, effectDuration));
        }
    }
}