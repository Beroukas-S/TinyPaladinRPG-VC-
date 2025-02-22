using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyBehaviour;

public class Enemy_Knockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private EnemyBehaviour enemyMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyBehaviour>();
    }

    public void KnockBack(Transform playerTransform, float force, float duration, float stuntime)
    {
        enemyMovement.ChangeState(EnemyState.KnockedBack);
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.velocity = direction * force;
        StartCoroutine(KnockTimer(duration, stuntime));

    }

    IEnumerator KnockTimer(float knocktime, float stun)
    {
        yield return new WaitForSeconds(knocktime);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(stun);
        enemyMovement.ChangeState(EnemyState.Idle);
    }



}
