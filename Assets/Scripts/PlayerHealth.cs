using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    public TMP_Text healthText;
    public Animator hpDamageAnim;

    public void Start()
    {
        healthText.text = "HEALTH " + PlayerStats.Instance.currentHP + "/" + PlayerStats.Instance.maxHP;
    }

    public void ChangeHP(int amount)
    {
        PlayerStats.Instance.currentHP += amount;
        hpDamageAnim.Play("Text_Damage");
        healthText.text = "HEALTH " + PlayerStats.Instance.currentHP + "/" + PlayerStats.Instance.maxHP;

        if (PlayerStats.Instance.currentHP > PlayerStats.Instance.maxHP)
        {
            PlayerStats.Instance.currentHP = PlayerStats.Instance.maxHP;
        }
        if (PlayerStats.Instance.currentHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
