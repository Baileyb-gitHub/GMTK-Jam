using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FloorSwitchLogic : MonoBehaviour
{
    
    public bool switchPressed = false;
    public List<string> tagsThatPress;

    private int pressingCount = 0;

    [Space]
    private Material pressedStatusMaterial;
    public Color pressedColour;
    public Color notPressedColour;

    [Header("Audio")]
    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private AudioClip pressedClip;
    [SerializeField] private AudioClip notPressedClip;

    [Header("Level Tracking")]
    [SerializeField] LevelMoniter myLevelMoniter;
    [SerializeField] bool prop = false;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        if(prop == false) 
        {
            myLevelMoniter = FindObjectOfType<LevelMoniter>();
        }

        var mats = GetComponent<Renderer>().materials;
        mats[0].color = notPressedColour;
        GetComponent<Renderer>().materials = mats;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tagsThatPress.Contains(other.tag)) 
        {
            pressingCount++;
            switchPressed = true;

            if (pressingCount == 1) 
            {
                myAudioSource.clip = pressedClip;
                myAudioSource.Play();
            }

            if (prop == false)
            {
                myLevelMoniter.CheckForVictory();
            }

            var mats =  GetComponent<Renderer>().materials;
            mats[0].color = pressedColour;
            GetComponent<Renderer>().materials = mats; 
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (tagsThatPress.Contains(other.tag))
        {
            pressingCount--;

            if(pressingCount < 1)
            {
                switchPressed = false;

                myAudioSource.clip = notPressedClip;
                myAudioSource.Play();

                var mats = GetComponent<Renderer>().materials;
                mats[0].color = notPressedColour;
                GetComponent<Renderer>().materials = mats;
            }

        }
    }

}
