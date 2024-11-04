using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynaGoblinMove : MonoBehaviour
{
    public float speed;
    public float attackRange;
    public float attackCD ;
    public float playerDetectDistance;
    public Transform detectionPoint;
    public LayerMask playerLayer;
    public Transform enemyCanvasTransform;

    public float attackCDtimer;
    private int faceDirection = 1;
    public EnemyState enemyState;


    private Rigidbody2D rb;
    private Transform player;
    private Animator animat;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animat = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);

    }

    // Update is called once per frame
    void Update()
    {


        //always checking for cooldown


        //core behaviour

        if (enemyState != EnemyState.KnockedBack)
        {
            if (attackCDtimer > 0)
            {
                attackCDtimer -= Time.deltaTime;
            }
            CheckForPlayer();
            if (enemyState == EnemyState.Moving)
            {
                Chase();
            }
            else if (enemyState == EnemyState.Attacking)
            {
                //attack
                rb.velocity = Vector2.zero;
            }
        }
        

    }

    void Chase()
    {
        if (player.position.x > transform.position.x && faceDirection == -1 || player.position.x < transform.position.x && faceDirection == 1)
        {
            Flip();
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void Flip()
    {
        faceDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        enemyCanvasTransform.localScale = new Vector3(enemyCanvasTransform.localScale.x * -1, enemyCanvasTransform.localScale.y, enemyCanvasTransform.localScale.z);
    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectDistance, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;

            //Range Check
            if (Vector2.Distance(transform.position, player.position) <= attackRange && attackCDtimer <= 0)
            {
                attackCDtimer = attackCD;
                ChangeState(EnemyState.Attacking);
            }
            else if ((Vector2.Distance(transform.position, player.position) > attackRange && attackCDtimer > 0))
            {
                ChangeState(EnemyState.Idle);
            }
            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Moving);
            }



        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    //change animation state for the enemy
    public void ChangeState(EnemyState newState)
    {
        if (enemyState == EnemyState.Idle)
        {
            animat.SetBool("isIdle", false);
        }
        else if (enemyState == EnemyState.Moving)
        {
            animat.SetBool("isMoving", false);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            animat.SetBool("isAttacking", false);
        }

        enemyState = newState;

        if (enemyState == EnemyState.Idle)
        {
            animat.SetBool("isIdle", true);
        }
        else if (enemyState == EnemyState.Moving)
        {
            animat.SetBool("isMoving", true);
        }
        else if (enemyState == EnemyState.Attacking)
        {
            animat.SetBool("isAttacking", true);
        }
    }


    //detection point range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectDistance);
    }
}

public enum DynaGoblinState
{
    Idle,
    Moving,
    Attacking,
    KnockedBack
}

