using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MerchantSpeech : MonoBehaviour
{
    public CanvasGroup playerCanvas;
    public bool inRange = false;
    public bool bubbleOn = false;
    public CanvasGroup shopCanvas;

    //placeholder interact button
    //public Transform player;



    // Update is called once per frame
    void Update()
    {
        //placeholder interact button
        if (Input.GetButtonDown("E") && inRange)
        {
            MerchantTalk();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCanvas.alpha = 1;
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCanvas.alpha = 0;
            inRange = false;
        }
    }

    
    private void MerchantTalk()
    {
        if (bubbleOn)
        {
            Time.timeScale = 1;
            shopCanvas.alpha = 0;
            shopCanvas.interactable = false;
            shopCanvas.blocksRaycasts = false;
            bubbleOn = false;
        }
        else
        {
            Time.timeScale = 0;
            //UpdateStats();
            shopCanvas.alpha = 1;
            shopCanvas.interactable = true;
            shopCanvas.blocksRaycasts = true;
            bubbleOn = true;
        }
    }
    

}
