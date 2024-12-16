using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField] private Player player;
    public float timer;

    public Animator animator;
    public PlayerAudio playerAudio;

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
            player.ChangeHealthState(Player.HealthState.Immune);
            player.ChangeMovementState(Player.MovementState.Blocking);
        }
    }

    public void BlockEnd()
    {
        animator.SetBool("onBlock", false);
        player.ChangeHealthState(Player.HealthState.Normal);
        timer = player.blockCD;
        playerAudio.StopSound();
    }


    public void PlayAudio()
    {
        playerAudio.BlockSound();
    }


}
