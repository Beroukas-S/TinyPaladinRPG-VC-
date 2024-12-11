using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerHealth playerhealth;
    public static PlayerStats Instance;
    public PlayerUISounds audioUI;
    private float diff;
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
    //public HealthState healthState;

    [Header("Health")]
    public float currentHP;
    public float maxHP;

    [Header("Movement")]
    public float speed;

    [Header("Gold")]
    public float gold;

    [Header ("Skills")]
    public bool fireball = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);
            currentHP = maxHP;
            //fireball = false;
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
        PickupGold.OnGoldPickup += GoldUpdate;
    }

    private void OnDisable()
    {
        ExpManager.OnLevelUp -= UpdateStats;
        PickupGold.OnGoldPickup -= GoldUpdate;
    }

    private void UpdateStats(int level)
    {
        meleeDamage += meleeDamage * level * statScaling;
        fireballDamage += fireballDamage * level * statScaling;
        diff = maxHP;
        maxHP += Mathf.RoundToInt(maxHP * level * statScaling);
        diff = maxHP - diff;
        currentHP += diff;
        playerhealth.UpdateCanvas();
    }


    public void GoldUpdate(float amount)
    { 
        gold += amount;
        playerhealth.UpdateCanvas();
        audioUI.GoldPickUpSound();
    }

    public void HaveFireball()
    {
        fireball = true;
    }
/*
    public enum HealthState
    {
        Normal,
        Immune,
        Vulnerable,
        Dead
    }

    public void ChangeState(HealthState newState)
    {
        healthState = newState;
    }*/


}
