using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class PlayerHealthMono : MonoBehaviour
{
    [SerializeField] private Player player;
    public TMP_Text healthText;
    public Animator hpDamageAnim;
    public Animator animator;
    private PlayerMovement playermovent;
    public PlayerAudio playerAudio;
    public new SpriteRenderer renderer;
    [SerializeField] private float wiggleTime;


    public void Start()
    {
        UpdateCanvas();
        player.ChangeHealthState(Player.HealthState.Normal);
        playermovent = GetComponent<PlayerMovement>();
        player.currentHP = player.maxHP;
        renderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeHP(float amount)
    {
        if (player.healthState == Player.HealthState.Normal)
        {
            if (player.currentHP + amount > player.maxHP)
            {
                player.currentHP = player.maxHP;
            }
            else if (player.currentHP + amount > 0)
            {
                player.currentHP += amount;
            }
            else if (player.currentHP + amount <= 0)
            {
                player.currentHP = 0;
                player.ChangeHealthState(Player.HealthState.Dead);
                player.ChangeMovementState(Player.MovementState.Dead);
                playerAudio.DeathSound();
                playermovent.rb.velocity = Vector2.zero;
                animator.SetTrigger("onDeath");
            }
            GetHitRed();
            hpDamageAnim.Play("Text_Damage");
            UpdateCanvas();
        }
    }

    public void UpdateCanvas()
    {
        healthText.text = "HEALTH " + player.currentHP + "/" + player.maxHP;
    }


    public void GetHitRed()
    {
        renderer.material.color = Color.red;
        StartCoroutine(HitWiggle(wiggleTime));
    }

    IEnumerator HitWiggle(float wiggleTime)
    {
        yield return new WaitForSecondsRealtime(wiggleTime);
        renderer.material.color = Color.white;
        yield return new WaitForSecondsRealtime(wiggleTime);
        renderer.material.color = Color.red;
        yield return new WaitForSecondsRealtime(wiggleTime);
        renderer.material.color = Color.white;

    }

    public void PlayerDeath()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
    }




}

