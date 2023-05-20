using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
   // [SpecializeField] AudioSource source;
    [SerializeField] public AudioSource source;
    [SerializeField] public AudioClip BellSound;
    [SerializeField] public AudioSource background;
    [SerializeField] public AudioMixer mixer;
    [SerializeField] public Slider slider;
    // Start is called before the first frame update
   // [SerializeField] GameObject audioManagerGO;
   // AudioManager audioManager;
    AudioClip currentClip = null;
    
    public void PlayAudio()
    {
       // source.clip = BellSound;
        source.PlayOneShot(BellSound, 0.75f);
    }

    public void SetVol()
    {
        mixer.SetFloat("MainVolume", slider.value);
    }

    public void PlayBackground(AudioClip clip) 
    {
       
        if (clip != currentClip)
        {
            background.clip = clip;
            background.Play();
            currentClip = clip;
        }
            
    }

    public void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

}

