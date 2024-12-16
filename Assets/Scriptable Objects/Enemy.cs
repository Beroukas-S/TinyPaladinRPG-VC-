using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    [SerializeField]
    public float attackRange, attackCD, playerDetectDistance;
    [SerializeField]
    public float speed, wanderTime, waitTime;
    [SerializeField]
    public float currentHP, maxHP;
    [SerializeField]
    public int expReward;    
}
