using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private float timer;

    public Animator animator;

    public PlayerHealth playerHealth;

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
            playerHealth.ChangeState(HealthState.Immune);
            
        }
    }

    public void BlockEnd()
    {
        animator.SetBool("onBlock", false);
        playerHealth.ChangeState(HealthState.Normal);
        timer = PlayerStats.Instance.blockCD;
    }


}
