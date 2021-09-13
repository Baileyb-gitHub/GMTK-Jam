using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTools : MonoBehaviour
{
    private AudioPlayer theAudioPlayer;

    private void Start()
    {
        theAudioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void PlaySound(string soundType)
    {
        theAudioPlayer.playSound(soundType);
    }

    public void PlayMusic(string soundType)
    {
        theAudioPlayer.playSound(soundType);
    }

    public void SetMusicVoume(float value)
    {
        theAudioPlayer.updateMusicVolume(value);
    }
    public void SetEffectsVolume(float value)
    {
        theAudioPlayer.updateEffectsVolume(value);
    }


    public void activateObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void deActivateObject(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void FlipActivation(GameObject obj)
    {
        if(obj.activeInHierarchy == true) 
        {
            obj.SetActive(false);
        }
        else 
        {
            obj.SetActive(true);
        }
    }

    public void LoadScene(string sceneName)
    {
        UnPause();
        SceneManager.LoadScene(sceneName);
    }

    public void exitApplication() 
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }

}
