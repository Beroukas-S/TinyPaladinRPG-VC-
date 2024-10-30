using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    //attack animation
    public Animator animator;
    private float quickTimer;
    private float heavyTimer;

    //attack damage and hitpoint
    public Transform attackPointHorizontal;
    public Transform attackPointUp;
    public Transform attackPointDown;

    public LayerMask enemyLayer;


    public void Update()
    {
        //cooldown timer 
        if (quickTimer > 0)
        {
            quickTimer -= Time.deltaTime;
        }
        if (heavyTimer > 0)
        { 
            heavyTimer -= Time.deltaTime;
        }
    }

    //attack animations for quick attacks and heavy attacks depending on direction
    public void QuickAttack()
    {
        if (quickTimer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isQatk", true);
            quickTimer = PlayerStats.Instance.quickAttackCD;
        }
    }



    public void QuickAttackUp()
    {
        if (quickTimer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isQatkUP", true);
            quickTimer = PlayerStats.Instance.quickAttackCD;
        }

    }

    public void QuickAttackDown()
    {
        if (quickTimer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isQatkDown", true);
            quickTimer = PlayerStats.Instance.quickAttackCD;
        }

    }

    public void HeavyAttack()
    {
        if (heavyTimer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isHatk", true);
            heavyTimer = PlayerStats.Instance.heavyAttackCD;
        }

    }

    public void HeavyAttackUp()
    {
        if (heavyTimer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isHatkUp", true);
            heavyTimer = PlayerStats.Instance.heavyAttackCD;
        }

    }

    public void HeavyAttackDown()
    {
        if (heavyTimer <= 0)
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isHatkDown", true);
            heavyTimer = PlayerStats.Instance.heavyAttackCD;
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
    }


    //attack damage for quick and heavy depending on direction
    public void DealDamageQuickAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointHorizontal.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.quickDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }

    public void DealDamageQuickAttackUp()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointUp.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.quickDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }

    public void DealDamageQuickAttackDown()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointDown.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.quickDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }

    public void DealDamageHeavyAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointHorizontal.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.heavyDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }

    public void DealDamageHeavyAttackUp()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointUp.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.heavyDamage);
            enemies[0].GetComponent<Enemy_Knockback>().KnockBack(transform, PlayerStats.Instance.knockBackForce, PlayerStats.Instance.knockBackTime, PlayerStats.Instance.knockBackStun);
        }
    }

    public void DealDamageHeavyAttackDown()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPointDown.position, PlayerStats.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHP(-PlayerStats.Instance.heavyDamage);
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
