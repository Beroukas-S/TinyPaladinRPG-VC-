using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public TMP_Text healthText;
    public Animator hpDamageAnim;
    public Animator animator;
    private PlayerMovement playermovent;

    public HealthState healthState;

    public void Start()
    {
        UpdateCanvas();
        ChangeState(HealthState.Normal);
        playermovent = GetComponent<PlayerMovement>();
        PlayerStats.Instance.currentHP = PlayerStats.Instance.maxHP;
    }

    public void ChangeHP(float amount)
    {
        if (healthState == HealthState.Normal)
        {
            if (PlayerStats.Instance.currentHP + amount > PlayerStats.Instance.maxHP)
            {
                PlayerStats.Instance.currentHP = PlayerStats.Instance.maxHP;
            }
            else if (PlayerStats.Instance.currentHP + amount > 0)
            {
                PlayerStats.Instance.currentHP += amount;
            }
            else if (PlayerStats.Instance.currentHP + amount <= 0)
            {
                PlayerStats.Instance.currentHP = 0;
                ChangeState(HealthState.Dead);
                playermovent.ChangeState(PlayerState.Dead);
                playermovent.rb.velocity = Vector2.zero;
                animator.SetTrigger("onDeath");
            }

            hpDamageAnim.Play("Text_Damage");
            UpdateCanvas();

        }

    }

    public void UpdateCanvas()
    {
        healthText.text = "HEALTH " + PlayerStats.Instance.currentHP + "/" + PlayerStats.Instance.maxHP;
    }


    public void ChangeState(HealthState newState)
    {
        healthState = newState;
    }

    public void PlayerDeath()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
    }

    public enum HealthState
    {
        Normal,
        Immune,
        Vulnerable,
        Dead
    }



}

