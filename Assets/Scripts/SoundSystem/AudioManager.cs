using System;
using UnityEngine;

namespace SoundSystem
{
	
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        public Sound[] sounds;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            foreach (var s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.outputAudioMixerGroup = s.mixer;
                s.source.playOnAwake = s.playOnAwake;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }
        public void Play(string sound)
        {
            var s = Array.Find(sounds, item => item.name == sound);
            s.source.Play();
        }
        public void Stop(string sound)
        {
            var s = Array.Find(sounds, item => item.name == sound);
            s.source.Stop();
        }
    }
}