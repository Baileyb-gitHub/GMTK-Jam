using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [Header("Volume Settings")]
     public float musicVolume;
     public float effectsVolume;
    [Header("Sound Lists (randomized)")]
    [SerializeField] private List<AudioClip> buttonSounds;
    [SerializeField] private List<AudioClip> victorySounds;
    [SerializeField] private List<AudioClip> resetSounds;
    [SerializeField] private List<AudioClip> musicSounds;
    [Header("Outputs")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;

    const int NOMUSICID = 0;
    const int MAINMUSICID = 1;

    /// <summary>
    /// plays sound effet based on input string (button,reset,victory)
    /// </summary>
    /// <param name="soundToPlay"> string Parameter value to pass.</param>
    public void playSound(string soundToPlay) 
    {
        switch (soundToPlay.ToLower()) 
        {
            case "button":
                effectsSource.clip = (buttonSounds[Random.Range(0, buttonSounds.Count - 1)]);
                effectsSource.Play();
                break;

            case "reset":
                effectsSource.clip = (resetSounds[Random.Range(0, resetSounds.Count - 1)]);
                effectsSource.Play();
                break;

            case "victory":
                effectsSource.clip = (victorySounds[Random.Range(0, victorySounds.Count - 1)]);
                effectsSource.Play();
                break;
        }
    }

    public void setMusic(int musicCode)
    {
        switch (musicCode)
        {
            case NOMUSICID:
                effectsSource.Stop();
                break;

            case MAINMUSICID:
                musicSource.clip = (musicSounds[MAINMUSICID]);
                effectsSource.Play();
                break;

        }
    }

    public void updateMusicVolume(float newVol) 
    {
        musicSource.volume = newVol;
    }

    public void updateEffectsVolume(float newVol)
    {
        effectsSource.volume = newVol;
    }

    public float getMusicVolume()
    {
        return musicSource.volume;
    }

    public float getEffectsVolume()
    {
        return effectsSource.volume;
    }

}
