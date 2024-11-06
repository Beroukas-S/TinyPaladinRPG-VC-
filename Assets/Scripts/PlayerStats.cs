using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerHealth playerhealth;
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
    public float blockCD;
    public float statScaling;

    [Header("Health")]
    public float currentHP;
    public float maxHP;

    [Header("Movement")]
    public float speed;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
        currentHP = maxHP;
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            currentHP = 0;
        }
    }

    private void OnEnable()
    {
        ExpManager.OnLevelUp += UpdateStats;
    }

    private void OnDisable()
    {
        ExpManager.OnLevelUp -= UpdateStats;
    }

    private void UpdateStats(int level)
    {
        meleeDamage += meleeDamage * level * statScaling;
        fireballDamage += fireballDamage * level * statScaling;
        maxHP += Mathf.RoundToInt(maxHP * level * statScaling);
        playerhealth.UpdateCanvas();
    }


}
