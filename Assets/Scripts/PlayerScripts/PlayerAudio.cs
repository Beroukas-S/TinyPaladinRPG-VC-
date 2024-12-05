using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSourceSteps;
    public AudioSource audioSource;
    public AudioClip steps;
    public AudioClip swordSound;
    public AudioClip blockSound;
    public AudioClip deathSound;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StopSound()
    { 
        audioSource.Stop();
    }

    public void StepSound()
    {
        if (!audioSourceSteps.isPlaying)
        {
            audioSourceSteps.pitch = 2;
            audioSourceSteps.PlayOneShot(steps, 0.05f);
        }
    }

    public void BlockSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(blockSound, 0.05f);
        }
    }


    public void SwordSound()
    {
        audioSource.PlayOneShot(swordSound, 0.05f);
    }
    public void DeathSound()
    {
        audioSource.PlayOneShot(deathSound, 0.09f);
    }

    
    
}
