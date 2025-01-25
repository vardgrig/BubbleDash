using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace SoundSystem
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        public AudioMixerGroup mixer;

        [Range(0f, 1f)]
        public float volume = 1;

        [Range(-3f, 3f)]
        public float pitch = 1;
        public bool loop = false;
        public bool playOnAwake;

        [HideInInspector]
        public AudioSource source;
    }
}