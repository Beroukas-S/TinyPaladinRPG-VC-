using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUISounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip lvlUpSound;
    public AudioClip goldPickupSound;
    public void LevelUpSound()
    {
        
        audioSource.PlayOneShot(lvlUpSound, 0.07f);
        
    }

    public void GoldPickUpSound()
    {
        
        audioSource.PlayOneShot(goldPickupSound, 0.07f);
        
    }
}
