using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    public float timer;

    public Animator animator;
    public PlayerAudio playerAudio;

    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        }
    }

    public void BlockEnd()
    {
        animator.SetBool("onBlock", false);
        playerHealth.ChangeState(PlayerHealth.HealthState.Normal);
        timer = PlayerStats.Instance.blockCD;
        playerAudio.StopSound();
    }


    public void PlayAudio()
    {
        playerAudio.BlockSound();
    }


}
