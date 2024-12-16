using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static Cinemachine.DocumentationSortingAttribute;

[CreateAssetMenu]
public class Player : ScriptableObject
{
    [SerializeField]
    public float meleeDamage, weaponRange, knockBackForce, knockBackTime, knockBackStun, attackCD;
    // 1, 0.7, 20, 0.05, 0.2, 0.2
    [SerializeField]
    public float blockCD, statScaling, fireballDamage, fireballCD;
    // 1.5, 0.1, 2, 2
    [SerializeField]
    public float currentHP, maxHP, speed, gold;
    // 0, 15, 5, 55
    [SerializeField]
    public bool fireball = false;
    [SerializeField] public HealthState healthState;
    [SerializeField] public MovementState moveState;
    private float diff;

    public void ChangeHealthState(HealthState newState)
    {
        healthState = newState;
    }

    public void ChangeMovementState(MovementState newState)
    {
        moveState = newState;
    }


    public enum HealthState
    {
        Normal,
        Immune,
        Vulnerable,
        Dead
    }

    public enum MovementState
    {
        Idle,
        Moving,
        KnockedBack,
        Attacking,
        Blocking,
        Dead
    }


}
