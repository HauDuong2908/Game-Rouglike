using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    private AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void PlayOneShot(AudioClip audioClip)
    {
        audioPlayer.PlayOneShot(audioClip);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
        // MasterVolume
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("SoundVolume", volume);
        // MusicVolume
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
}
