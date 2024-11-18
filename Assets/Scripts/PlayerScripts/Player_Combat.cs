using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    //attack animation
    public Animator animator;
    private float timer;

    //attack damage and hitpoint
    public Transform attackPointHorizontal;
    public Transform attackPointUp;
    public Transform attackPointDown;

    public LayerMask enemyLayer;

    public PlayerMovement playerMovement;


    public void Update()
    {
        //cooldown timer 
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    //attack animations for quick attacks and heavy attacks depending on direction
    public void QuickAttack()
    {
        if (timer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isQatk", true);
            timer = PlayerStats.Instance.attackCD;
        }
    }



    public void QuickAttackUp()
    {
        if (timer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isQatkUP", true);
            timer = PlayerStats.Instance.attackCD;
        }

    }

    public void QuickAttackDown()
    {
        if (timer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isQatkDown", true);
            timer = PlayerStats.Instance.attackCD;
        }

    }

    public void HeavyAttack()
    {
        if (timer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isHatk", true);
            timer = PlayerStats.Instance.attackCD;
        }

    }

    public void HeavyAttackUp()
    {
        if (timer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isHatkUp", true);
            timer = PlayerStats.Instance.attackCD;
        }

    }

    public void HeavyAttackDown()
    {
        if (timer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isHatkDown", true);
            timer = PlayerStats.Instance.attackCD;
        }

    }

    //animation ending
    public void FinishAttack()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isQatk", false);
        animator.SetBool("isQatkDown", false);
        animator.SetBool("isQatkUP", false);
        animator.SetBool("isHatk", false);
        animator.SetBool("isHatkUp", false);
        animator.SetBool("isHatkDown", false);
        playerMovement.ChangeState(PlayerState.Idle);
    }


    //attack damage for quick and heavy depending on direction
    public void DealDamageQuickAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointHorizontal.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.meleeDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }

    public void DealDamageQuickAttackUp()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointUp.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.meleeDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }

    public void DealDamageQuickAttackDown()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointDown.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.meleeDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }

    public void DealDamageHeavyAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointHorizontal.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.meleeDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }

    public void DealDamageHeavyAttackUp()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointUp.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.meleeDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }

    public void DealDamageHeavyAttackDown()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointDown.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.meleeDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }



    private void OnDrawGizmosSelected()
    {
        //sword attack ranges
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPointHorizontal.position, PlayerStats.Instance.weaponRange);
        Gizmos.DrawWireSphere(attackPointDown.position, PlayerStats.Instance.weaponRange);
        Gizmos.DrawWireSphere(attackPointUp.position, PlayerStats.Instance.weaponRange);
    }


}
