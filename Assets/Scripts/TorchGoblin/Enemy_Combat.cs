using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;
    public Transform attackPoint;
    public float weaponRange;
    public float knockBackForce;
    public float knockTime = 1;
    public LayerMask playerLayer;


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
            hits[0].GetComponent<PlayerHealth>().ChangeHP(-damage);
            if (PlayerStats.Instance.currentHP > 0)
            {
                hits[0].GetComponent<PlayerMovement>().KnockBack(transform, knockBackForce, knockTime);
            }
            
        }
    }


}