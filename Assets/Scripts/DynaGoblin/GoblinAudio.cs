using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip throwSound;
    [SerializeField] private AudioClip blockedSound;

    public void ThrowSound()
    {
        audioSource.PlayOneShot(throwSound, 0.05f);
    }

    public void BlockedHitSound()
    {
        audioSource.PlayOneShot(blockedSound, 0.05f);
    }

}
