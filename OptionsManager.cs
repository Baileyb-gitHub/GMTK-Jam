using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    [SerializeField] private AudioPlayer myAudioBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        myAudioBehaviour = FindObjectOfType<AudioPlayer>();
        musicSlider.value = myAudioBehaviour.getMusicVolume();
        effectsSlider.value = myAudioBehaviour.getEffectsVolume();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateMusicVol() 
    {
        myAudioBehaviour.updateMusicVolume(musicSlider.value);
     
    }
    public void updateEffectsVol()
    {
        myAudioBehaviour.updateEffectsVolume(effectsSlider.value);
    }

    public void updateScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
   
}
