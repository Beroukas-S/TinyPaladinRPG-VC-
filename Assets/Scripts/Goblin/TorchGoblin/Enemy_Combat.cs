using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    [SerializeField] private Player player;
    public float damage = 1;
    public Transform attackPoint;
    public float weaponRange;
    public float knockBackForce;
    public float knockTime = 1;
    public LayerMask playerLayer;
    public GoblinAudio goblinAudio;


    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHP(-damage);
        }
    }
    */


    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);
        if (hits.Length > 0)
        {
            goblinAudio.ThrowSound();
            hits[0].GetComponent<PlayerHealthMono>().ChangeHP(-damage);
            if (player.currentHP > 0)
            {
                hits[0].GetComponent<PlayerMovement>().KnockBack(transform, knockBackForce, knockTime);
            }


        }
    }


}