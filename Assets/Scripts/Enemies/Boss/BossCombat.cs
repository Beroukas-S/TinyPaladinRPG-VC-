using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private EnemyBoss boss;
    public Transform attackPoint;
    public float weaponRange;
    public float knockBackForce;
    public float knockTime = 1;
    public LayerMask playerLayer;
    public GoblinAudio goblinAudio;
    public bool gizmosOn;

    public GameObject projectile;
    public Transform projectileTransform;
    public Transform projectileRotationPoint;
    public Transform playerTransform;

    private void Update()
    {
        Vector3 rotation = playerTransform.position - projectileRotationPoint.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        projectileRotationPoint.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);
        if (hits.Length > 0)
        {
            goblinAudio.ThrowSound();
            hits[0].GetComponent<PlayerHealthMono>().ChangeHP(-boss.attackDamage);
            if (player.currentHP > 0)
            {
                hits[0].GetComponent<PlayerMovement>().KnockBack(transform, knockBackForce, knockTime);
            }
        }
    }

    public void shoot()
    {
        //goblinAudio.ThrowSound();

        GameObject projectileCreate = Instantiate(projectile, projectileTransform.position, Quaternion.identity);

        //για να δώσω τιμή στο sorting layer
        var MyScript = projectileCreate.GetComponent<SpriteRenderer>();
        MyScript.sortingOrder = 15;

        //Για το ποιος έφτιαξε το fireball
        ProjectileScript myProjectileScript = projectileCreate.GetComponent<ProjectileScript>();
        myProjectileScript.Initialize(false);
    }

    private void OnDrawGizmosSelected()
    {
        if (gizmosOn == true)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
        }
    }

}
