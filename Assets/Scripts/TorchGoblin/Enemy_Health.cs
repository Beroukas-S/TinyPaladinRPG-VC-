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

    public GameObject gold;
    public SpriteRenderer enemyRenderer;

    private void Awake()
    {
        healthbar = GetComponentInChildren<EnemyHealthbar>();
        enemyRenderer = GetComponent<SpriteRenderer>();
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
            

            //spawn Gold
            GameObject goldDrop = Instantiate(gold, transform.position, Quaternion.identity);

            //για να δώσω τιμή στο sorting layer
            var goldSprite = goldDrop.GetComponent<SpriteRenderer>();
            goldSprite.sortingOrder = enemyRenderer.sortingOrder;

            Destroy(gameObject);

        }
    }


}
