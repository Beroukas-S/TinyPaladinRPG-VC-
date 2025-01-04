using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public LayerMask playerLayer;
    public Transform attackPoint;
    public GameObject projectile; 
    public GoblinAudio goblinAudio;


    public void Throw()
    {
        goblinAudio.ThrowSound();
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, enemy.attackRange, playerLayer);
        if (hits.Length > 0)
        {
            GameObject arrowCreate = Instantiate(projectile, attackPoint.position, Quaternion.identity);

            var MyScript = arrowCreate.GetComponent<SpriteRenderer>();
            MyScript.sortingOrder = 15;

        }
    }
}
