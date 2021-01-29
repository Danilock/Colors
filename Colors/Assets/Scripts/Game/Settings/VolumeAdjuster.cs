using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeAdjuster : MonoBehaviour
{
    [SerializeField] AudioMixerGroup _SfxGroup, _MusicGroup;

    public void SetSfxVolume(float volume) => _SfxGroup.audioMixer.SetFloat("SfxVol", volume);

    public void SetMusicVolume(float volume) => _MusicGroup.audioMixer.SetFloat("MusicVol", volume);
}
