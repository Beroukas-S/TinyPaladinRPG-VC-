using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip steps;
    public AudioClip swordSound;

    public void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void PlaySteps()
    {
        if (!audiosource.isPlaying)
        {
            audiosource.pitch = 2;
            audiosource.PlayOneShot(steps, 0.05f);
        }
    }

    public void StopSteps()
    {
        audiosource.pitch = 1;
        audiosource.Stop();
    }

    public void PlaySwordSound()
    {
        audiosource.PlayOneShot(swordSound, 0.05f);
    }
    
}
