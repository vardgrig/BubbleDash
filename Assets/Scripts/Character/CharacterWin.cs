using General;
using UnityEngine;

namespace Character
{
    public class CharacterWin : MonoBehaviour
    {
        [SerializeField] private float timeToLoad;
        [SerializeField] private string levelToLoad;
        private void OnEnable()
        {
            CharacterEvents.Win += OnWin;
        }

        private void OnDisable()
        {
            CharacterEvents.Win -= OnWin;
        }

        private void OnWin(float timeToLoad)
        {
            StartCoroutine(SceneLoader.LoadSceneAsync(levelToLoad, timeToLoad));
        }
    }
}