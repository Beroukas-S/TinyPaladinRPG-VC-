using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    //public float speed;
    //public float attackRange;
    //public float attackCD;
    //public float playerDetectDistance;
    //public float wanderTime;
    //public float waitTime;

    public Transform detectionPoint;
    public LayerMask playerLayer;
    public Transform enemyCanvasTransform;

    private float attackCDtimer;
    private float faceDirection;


    private float timerBeforeWander;


    private Rigidbody2D rb;
    private Transform player;
    private Animator animat;
    public EnemyState enemyState;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animat = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
        faceDirection = transform.localScale.x;
        timerBeforeWander = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //so as not to be pushed around by colliding with him
        if (enemyState == EnemyState.Idle)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        //always checking for cooldown


        //core behaviour

        if (enemyState != EnemyState.KnockedBack && enemyState != EnemyState.Wandering)
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
            else if (enemyState == EnemyState.Idle)
            {
                if (timerBeforeWander > 0)
                {
                    timerBeforeWander -= Time.deltaTime;
                }
                else
                {
                    Wander();
                }
            }
        }


    }

    void Chase()
    {
        if (player.position.x > transform.position.x && faceDirection < 0 || player.position.x < transform.position.x && faceDirection > 0)
        {
            Flip();
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * enemy.speed;
    }

    private void Flip()
    {
        faceDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        enemyCanvasTransform.localScale = new Vector3(enemyCanvasTransform.localScale.x * -1, enemyCanvasTransform.localScale.y, enemyCanvasTransform.localScale.z);
    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, enemy.playerDetectDistance, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;

            //Range Check
            if (Vector2.Distance(transform.position, player.position) <= enemy.attackRange && attackCDtimer <= 0)
            {
                attackCDtimer = enemy.attackCD;
                ChangeState(EnemyState.Attacking);
            }
            else if ((Vector2.Distance(transform.position, player.position) > enemy.attackRange && attackCDtimer > 0) && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Idle);
            }
            else if (Vector2.Distance(transform.position, player.position) > enemy.attackRange && enemyState != EnemyState.Attacking)
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
        if (enemyState == EnemyState.Moving)
        {
            animat.SetBool("isMoving", false);
        }
        if (enemyState == EnemyState.Attacking)
        {
            animat.SetBool("isAttacking", false);
        }
        if (enemyState == EnemyState.Wandering)
        {
            animat.SetBool("isMoving", false);
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
        if (enemyState == EnemyState.Wandering)
        {
            animat.SetBool("isMoving", true);
        }
    }


    //detection point range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, enemy.playerDetectDistance);
    }


    private void Wander()
    {
        ChangeState(EnemyState.Wandering);
        Vector3 randPosition = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 1f);//.normalized;
        Vector2 randDirection = (randPosition - transform.position).normalized;

        rb.velocity = randDirection * (enemy.speed /2);
        timerBeforeWander = enemy.waitTime;
        StartCoroutine(WanderTimer(enemy.wanderTime));

    }
    
    IEnumerator WanderTimer(float movetime)
    {
        yield return new WaitForSeconds(movetime);
        rb.velocity = Vector2.zero;
        ChangeState(EnemyState.Idle);
    }

    public enum EnemyState
    {
        Idle,
        Moving,
        Attacking,
        KnockedBack,
        Wandering
    }

}

