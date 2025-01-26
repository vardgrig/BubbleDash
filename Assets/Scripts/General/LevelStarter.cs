using DG.Tweening;
using SoundSystem;
using UnityEngine;

namespace General
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private CanvasGroup faderGroup;
        //[SerializeField] private string bgMusicName;

        private void Start()
        {
            //AudioManager.instance.Play(bgMusicName);
            faderGroup.DOFade(0, fadeDuration);
        }
    }
}