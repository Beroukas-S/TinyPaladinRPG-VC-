using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Slider healthBar;


    public void UpdateHealthBar(float currentHP,float maxHP)
    { 
        healthBar.value = currentHP / maxHP;
    }


    
}
