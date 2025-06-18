using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public delegate void EnemyDefeated(int exp);
    public static event EnemyDefeated OnEnemyDefeated;
    public float currentHP;

    private EnemyHealthbar healthbar;

    public GameObject gold;
    public SpriteRenderer enemyRenderer;
    [SerializeField] private float wiggleTime;
    private void Awake()
    {
        healthbar = GetComponentInChildren<EnemyHealthbar>();
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        currentHP = enemy.maxHP;
        healthbar.UpdateHealthBar(currentHP, enemy.maxHP);
    }

    public void ChangeHP(float amount)
    {
        currentHP += amount;  

        if (currentHP > enemy.maxHP)
        {
            currentHP = enemy.maxHP;
        }
        healthbar.UpdateHealthBar(currentHP, enemy.maxHP);
        if (currentHP <= 0)
        {
            OnEnemyDefeated(enemy.expReward);

            GoldDrop();
            
            Destroy(gameObject);
        }
        GetHitRed();
    }

    public void GetHitRed()
    {
        enemyRenderer.material.color = Color.red;
        StartCoroutine(HitWiggle(wiggleTime));
    }

    IEnumerator HitWiggle(float wiggleTime)
    {
        yield return new WaitForSecondsRealtime(wiggleTime);
        enemyRenderer.material.color = Color.white;
        yield return new WaitForSecondsRealtime(wiggleTime);
        enemyRenderer.material.color = Color.red;
        yield return new WaitForSecondsRealtime(wiggleTime);
        enemyRenderer.material.color = Color.white;

    }



    public void GoldDrop()
    {
        //spawn Gold
        GameObject goldDrop = Instantiate(gold, transform.position, Quaternion.identity);
        //για να δώσω τιμή στο sorting layer
        var goldSprite = goldDrop.GetComponent<SpriteRenderer>();
        goldSprite.sortingOrder = enemyRenderer.sortingOrder;
    }


}
