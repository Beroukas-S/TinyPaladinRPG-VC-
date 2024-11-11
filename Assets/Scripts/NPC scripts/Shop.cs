using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PlayerStats playerStats;
    public Button button;


    // Start is called before the first frame update
    public void BuySpell()
    {
        if (PlayerStats.Instance.gold >= 50)
        {
            playerStats.GoldUpdate(-50);
            button.interactable = false;
            button.gameObject.SetActive(false);


        }
    }
}
