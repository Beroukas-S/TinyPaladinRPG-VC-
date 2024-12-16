using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private Player player;
    public GameObject[] statSquares;
    public CanvasGroup statsCanvas;


    private void Update()
    {
        UpdateStats();
    }



    public void UpdateStrengthStat()
    {
        statSquares[0].GetComponentInChildren<TMP_Text>().text = "Strength: " + player.meleeDamage;
    }

    public void UpdateSpeedStat()
    {
        statSquares[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + player.speed;
    }

    public void UpdateHealthStat()
    {
        statSquares[2].GetComponentInChildren<TMP_Text>().text = "Health: " + player.maxHP;
    }

    public void UpdateGoldStat()
    {
        statSquares[3].GetComponentInChildren<TMP_Text>().text = "Gold: " + player.gold;
    }

    public void UpdateStats()
    {
        UpdateStrengthStat();
        UpdateSpeedStat();
        UpdateHealthStat();
        UpdateGoldStat();
    }

}
