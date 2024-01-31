using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
   
    public static SoundController instance;
    private void Awake()
    {
        instance = this;
    }

    public void PlaySound(string clipname, float volumeAudio)
    {
        AudioSource audioSource =  gameObject.AddComponent<AudioSource>();
        audioSource.volume *= volumeAudio;
        audioSource.PlayOneShot((AudioClip)Resources.Load("Sounds/" + clipname, typeof(AudioClip)));

    }
}
