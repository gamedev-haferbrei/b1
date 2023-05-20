using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    [SerializeField] public Slider slider;
    [SerializeField] public AudioMixer mixer;
    // Start is called before the first frame update
    
    void Start()
    {
        mixer.GetFloat("MainVolume", out float vol);
        slider.value = vol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
