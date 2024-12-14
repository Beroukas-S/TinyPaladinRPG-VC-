using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statSquares;
    public CanvasGroup statsCanvas;


    private void Update()
    {
        UpdateStats();
        //statsCanvas.alpha = 0;
    }

    //private void Update()
    //{
        
    //}


    public void UpdateStrengthStat()
    {
        statSquares[0].GetComponentInChildren<TMP_Text>().text = "Strength: " + PlayerStats.Instance.meleeDamage;
    }

    public void UpdateSpeedStat()
    {
        statSquares[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + PlayerStats.Instance.speed;
    }

    public void UpdateHealthStat()
    {
        statSquares[2].GetComponentInChildren<TMP_Text>().text = "Health: " + PlayerStats.Instance.maxHP;
    }

    public void UpdateGoldStat()
    {
        statSquares[3].GetComponentInChildren<TMP_Text>().text = "Gold: " + PlayerStats.Instance.gold;
    }

    public void UpdateStats()
    {
        UpdateStrengthStat();
        UpdateSpeedStat();
        UpdateHealthStat();
        UpdateGoldStat();
    }

}
