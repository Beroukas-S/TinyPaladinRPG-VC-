using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyBoss;

[CreateAssetMenu]
public class EnemyBoss : ScriptableObject
{
    [SerializeField]
    public float attackRange, attackCD, playerDetectDistance, attackDamage;
    [SerializeField]
    public float projectileRange, projectileCD, projectileDamage;
    [SerializeField]
    public float speed; //waitTime, wanderTime;
    [SerializeField]
    public float maxHP;
    [SerializeField]
    public int expReward;
}