using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] private PlayerHealthMono playerhealth;
    [SerializeField] private Player player;
    //public static PlayerStats Instance;
    [SerializeField] private PlayerUISounds audioUI;
    private float diff;
    [SerializeField] private Objective objectiveSecond;
    [SerializeField] public int enemyKillCount;


    private void Update()
    {
        if (player.currentHP <= 0)
        {
            player.currentHP = 0;
        }
    }

    private void OnEnable()
    {
        ExpManager.OnLevelUp += UpdateStats;
        PickupGold.OnGoldPickup += GoldUpdate;
        Enemy_Health.OnEnemyDefeated += EnemyKillCounter;
    }

    private void OnDisable()
    {
        ExpManager.OnLevelUp -= UpdateStats;
        PickupGold.OnGoldPickup -= GoldUpdate;
        Enemy_Health.OnEnemyDefeated -= EnemyKillCounter;
    }

    private void EnemyKillCounter(int nothing)
    {
        enemyKillCount++;
        objectiveSecond.ProgressObjective();
    }

    private void UpdateStats(int level)
    {
        player.meleeDamage += player.meleeDamage * level * player.statScaling;
        player.fireballDamage += player.fireballDamage * level * player.statScaling;
        diff = player.maxHP;
        player.maxHP += Mathf.RoundToInt(player.maxHP * level * player.statScaling);
        diff = player.maxHP - diff;
        player.currentHP += diff;
        playerhealth.UpdateCanvas();
    }


    public void GoldUpdate(float amount)
    {
        player.gold += amount;
        playerhealth.UpdateCanvas();
        audioUI.GoldPickUpSound();
    }

    public void HaveFireball()
    {
        player.fireball = true;
    }
}
