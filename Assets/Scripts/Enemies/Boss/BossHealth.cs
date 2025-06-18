using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private EnemyBoss boss;
    public delegate void EnemyDefeated(int exp);
    public static event EnemyDefeated OnEnemyDefeated;
    public float currentHP;
    public Animator animator;
    public CanvasGroup bossCanvasGroup;
    private EnemyHealthbar healthbar;

    public GameObject gold;
    public SpriteRenderer enemyRenderer;
    [SerializeField] private float wiggleTime;
    [SerializeField] private Objective objectiveThird;
    [SerializeField] private CapsuleCollider2D bossCollider;
    [SerializeField] private Rigidbody2D bossRb;

    private void Awake()
    {
        healthbar = GetComponentInChildren<EnemyHealthbar>();
        enemyRenderer = GetComponent<SpriteRenderer>();
        bossRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHP = boss.maxHP;
        healthbar.UpdateHealthBar(currentHP, boss.maxHP);
    }

    public void ChangeHP(float amount)
    {
        currentHP += amount;


        if (currentHP > boss.maxHP)
        {
            currentHP = boss.maxHP;
        }
        healthbar.UpdateHealthBar(currentHP, boss.maxHP);
        if (currentHP <= 0)
        {
            bossCanvasGroup.alpha = 0;
            bossRb.velocity = Vector2.zero;
            bossCollider.enabled = false;
            animator.SetTrigger("onDeath");

            //GoldDrop();

            objectiveThird.ProgressObjective();
            OnEnemyDefeated(boss.expReward);

        }
        GetHitRed();
    }

    public void GetHitRed()
    {
        enemyRenderer.material.color = Color.red;
        StartCoroutine(HitWiggle(wiggleTime));
    }

    public void death()
    {
        Destroy(gameObject);
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
