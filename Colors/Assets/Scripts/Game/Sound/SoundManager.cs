  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Sound
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager _instance;

        public static SoundManager Instance
        {
            get
            {
                if(_instance == null)
                    Debug.LogError("There's no Sound Manager in the scene");
                
                return _instance;
            }
        }
        
        [SerializeField] Sound[] sounds;

        // Start is called before the first frame update
        void Awake()
        {
            if(_instance != null && _instance != this)
                Destroy(gameObject);
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.outputAudioMixerGroup = s.output;
            }
        }

        public void Play(string name)
        {
            Sound s = System.Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("The:{" + name + "} sound could not be found.");
                return;
            }

            s.source.Play();
        }
    }
}