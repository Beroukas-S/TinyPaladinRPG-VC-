using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int expReward;
    public delegate void EnemyDefeated(int exp);
    public static event EnemyDefeated OnEnemyDefeated;

    public float currentHP;
    public float maxHP;

    private EnemyHealthbar healthbar;

    private void Awake()
    {
        healthbar = GetComponentInChildren<EnemyHealthbar>();
    }

    void Start()
    {
        currentHP = maxHP;
        healthbar.UpdateHealthBar(currentHP, maxHP);
    }

    public void ChangeHP(float amount)
    {
        currentHP += amount;
        

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        healthbar.UpdateHealthBar(currentHP,maxHP);
        if (currentHP <= 0)
        {
            OnEnemyDefeated(expReward);
            Destroy(gameObject);
        }
    }


}
