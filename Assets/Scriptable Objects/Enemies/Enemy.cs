using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    [SerializeField]
    public float attackRange, attackCD, playerDetectDistance, attackDamage;
    [SerializeField]
    public float speed; //waitTime, wanderTime;
    [SerializeField]
    public float maxHP;
    [SerializeField]
    public int expReward;    
}
