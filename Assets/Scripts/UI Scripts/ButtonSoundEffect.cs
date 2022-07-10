using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundEffect : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip buttonSound; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    public void SoundPlay()
    {
        GetComponent<AudioSource>().clip = buttonSound;
        GetComponent<AudioSource>().Play();
    }
}
