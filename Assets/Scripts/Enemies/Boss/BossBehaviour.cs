using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyBoss boss;

    public Transform detectionPoint;
    public LayerMask playerLayer;
    public Transform enemyCanvasTransform;

    private float attackCDtimer;
    private float fireballCDTimer;
    private float faceDirection;
    private bool hasSeen;
    public bool gizmosOn;

    private Rigidbody2D rb;
    private Transform player;
    public Animator animat;
    public BossCombat bossCombat;

    public EnemyState enemyState;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animat = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
        faceDirection = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //so as not to be pushed around by colliding with him
        if (enemyState == EnemyState.Idle)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.velocity = Vector2.zero;

        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        //core behaviour


        if (attackCDtimer > 0)
        {
            attackCDtimer -= Time.deltaTime;
        }
        if (fireballCDTimer > 0)
        {
            fireballCDTimer -= Time.deltaTime;
        }
        CheckForPlayer();
        if (enemyState == EnemyState.Moving)
        {
            this.Chase();
        }
        else if (enemyState == EnemyState.Attacking)
        {
            //attack
            rb.velocity = Vector2.zero;
        }

        if (hasSeen == true
            && fireballCDTimer <= 0)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            if (Vector2.Distance(transform.position, player.position) > boss.attackRange
                && Vector2.Distance(transform.position, player.position) <= boss.projectileRange)
            {
                fireballCDTimer = boss.projectileCD;
                bossCombat.shoot();
            }

        }

    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, boss.playerDetectDistance, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;

            if (hasSeen == false)
            {
                hasSeen = true;
            }

            //Range Check
            if (Vector2.Distance(transform.position, player.position) <= boss.attackRange 
                && attackCDtimer <= 0)
            {
                attackCDtimer = boss.attackCD;
                ChangeState(EnemyState.Attacking);
            }
            else if ((Vector2.Distance(transform.position, player.position) > boss.attackRange 
                && attackCDtimer > 0) 
                && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Idle);
                Flip();
            }
            else if (Vector2.Distance(transform.position, player.position) > boss.attackRange 
                && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Moving);
                Flip();
            }
            
        }

        else
        {
            rb.velocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    public void Chase()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * boss.speed;
    }

    private void Flip()
    {
        if (player.position.x > transform.position.x && faceDirection < 0 || player.position.x < transform.position.x && faceDirection > 0)
        {
            faceDirection *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            enemyCanvasTransform.localScale = new Vector3(enemyCanvasTransform.localScale.x * -1, enemyCanvasTransform.localScale.y, enemyCanvasTransform.localScale.z);
        }
    }

    //change animation state for the enemy
    public void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Idle)
        {
            animat.SetBool("isIdle", false);
        }
        if (enemyState == EnemyState.Moving)
        {
            animat.SetBool("isMoving", false);
        }
        if (enemyState == EnemyState.Attacking)
        {
            animat.SetBool("isAttacking", false);
        }
        

        enemyState = newState;

        if (enemyState == EnemyState.Idle)
        {
            animat.SetBool("isIdle", true);
        }
        if (enemyState == EnemyState.Moving)
        {
            animat.SetBool("isMoving", true);
        }
        if (enemyState == EnemyState.Attacking)
        {
            animat.SetBool("isAttacking", true);
        }
        
    }

    public enum EnemyState
    {
        Idle,
        Moving,
        Attacking
    }

    private void OnDrawGizmosSelected()
    {
        if (gizmosOn == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(detectionPoint.position, boss.playerDetectDistance);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, boss.projectileRange);
        }
    }
}
