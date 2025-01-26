using SoundSystem;
using UnityEngine;

namespace General
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] private string bgMusicName;

        private void Start()
        {
            AudioManager.instance.Play(bgMusicName);
        }
    }
}