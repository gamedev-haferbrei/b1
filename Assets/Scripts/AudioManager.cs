using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   // [SpecializeField] AudioSource source;
    [SerializeField] public AudioSource source;
    [SerializeField] public AudioClip BellSound;
    // Start is called before the first frame update
   // [SerializeField] GameObject audioManagerGO;
   // AudioManager audioManager;


    public void PlayAudio()
    {
        source.clip = BellSound;
        source.PlayOneShot(BellSound, 0.5f);
    }

    public void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

}

