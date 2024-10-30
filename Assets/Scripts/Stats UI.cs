using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statSquares;
    public CanvasGroup statsCanvas;

    private bool statsOpen = false;

    private void Start()
    {
        UpdateStats();
        statsCanvas.alpha = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("ToggleStats"))
        {
            if (statsOpen)
            {
                Time.timeScale = 1;
                statsCanvas.alpha = 0;
                statsOpen = false;
            }
            else 
            {
                Time.timeScale = 0;
                UpdateStats();
                statsCanvas.alpha = 1;
                statsOpen = true;
            }
        }
    }


    public void UpdateStrengthStat()
    {
        statSquares[0].GetComponentInChildren<TMP_Text>().text = "Strength: " + PlayerStats.Instance.quickDamage;
    }

    public void UpdateSpeedStat()
    {
        statSquares[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + PlayerStats.Instance.speed;
    }

    public void UpdateHealthStat()
    {
        statSquares[2].GetComponentInChildren<TMP_Text>().text = "Health: " + PlayerStats.Instance.maxHP;
    }


    public void UpdateStats()
    {
        UpdateStrengthStat();
        UpdateSpeedStat();
        UpdateHealthStat();
    }

}
