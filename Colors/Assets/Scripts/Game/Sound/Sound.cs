using UnityEngine;
using UnityEngine.Audio;

namespace Game.Sound
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        public AudioMixerGroup output;

        [Range(0f, 1f)] public float volume;
        [Range(.1f, 3f)] public float pitch;
        [HideInInspector] public AudioSource source;
        public bool loop;
    }
}