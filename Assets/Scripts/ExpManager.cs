using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpManager : MonoBehaviour
{
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    public float expGrowth = 1.2f;
    public Slider expSlider;
    public TMP_Text currentLevelText;
    //public Animator levelAnim;
    public GameObject playerEffects;

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Test"))
        {
            GainExp(5);
        }
    }

    private void OnEnable()
    {
        Enemy_Health.OnEnemyDefeated += GainExp;
    }

    private void OnDisable()
    {
        Enemy_Health.OnEnemyDefeated -= GainExp;
    }

    public void GainExp(int amount)
    { 
        currentExp += amount;
        if (currentExp >= expToLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }

    public void LevelUp()
    {
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrowth);
        playerEffects.GetComponent<Animator>().SetBool("onLvlUp", true);
    }


    private void UpdateUI()
    { 
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level: " + level;
    }

    
}
