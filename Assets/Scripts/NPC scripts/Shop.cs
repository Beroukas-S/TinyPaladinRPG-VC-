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
    public float timer;
    public CanvasGroup canvasGroup;
    

    // Start is called before the first frame update
    public void BuySpell()
    {
        if (PlayerStats.Instance.gold >= 50)
        {
            playerStats.GoldUpdate(-50);
            button.interactable = false;
            button.gameObject.SetActive(false);
            playerStats.BuyFireball();
            //PlayerSkills.Instance.fireball = true;
        }
        else if (PlayerStats.Instance.gold < 50)
        {
            canvasGroup.alpha = 1;
            StartCoroutine(InsufficientPopUp(timer));


        }
    }
    
    IEnumerator InsufficientPopUp(float time)
    {
        yield return new WaitForSeconds(time);
        canvasGroup.alpha = 0;
    }


}
