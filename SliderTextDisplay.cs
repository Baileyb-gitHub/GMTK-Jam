using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderTextDisplay : MonoBehaviour
{
    [SerializeField] string valuePreface;
    [SerializeField] Slider slider;
    [SerializeField] TMP_Text text;

    public void updateText() 
    {
        text.text = valuePreface +  Mathf.Round(slider.value * 100f) / 100f;


    }

  

}
