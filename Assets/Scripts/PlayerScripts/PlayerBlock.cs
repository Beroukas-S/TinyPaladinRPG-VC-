using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private float timer;

    public Animator animator;
    public AudioSource audioSource;

    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (timer > 0)
        { 
            timer -= Time.deltaTime;
        }
    }


    public void Block()
    {
        if (timer <= 0)
        {
            animator.SetBool("onBlock", true);
            playerHealth.ChangeState(PlayerHealth.HealthState.Immune);
            playerMovement.ChangeState(PlayerState.Blocking);
            if (!(audioSource.isPlaying))
            {
                audioSource.Play();
            }
        }
    }

    public void BlockEnd()
    {
        animator.SetBool("onBlock", false);
        playerHealth.ChangeState(PlayerHealth.HealthState.Normal);
        timer = PlayerStats.Instance.blockCD;
        audioSource.Stop();
    }


}
