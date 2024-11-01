using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    [Header("Combat Stats")]
    public float meleeDamage;
    public float weaponRange;
    public float knockBackForce;
    public float knockBackTime;
    public float knockBackStun;
    public float attackCD;
    public float fireballDamage;
    public float fireballCD;

    [Header("Health")]
    public int currentHP;
    public int maxHP;

    [Header("Movement")]
    public int speed;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
    }

}
