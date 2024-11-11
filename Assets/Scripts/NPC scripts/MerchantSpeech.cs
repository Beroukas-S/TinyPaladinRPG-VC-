using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantSpeech : MonoBehaviour
{
    public CanvasGroup playerCanvas;
    public bool inRange = false;

    //placeholder interact button
    //public Transform player;

    

    // Update is called once per frame
    void Update()
    {
        //placeholder interact button
        if (Input.GetButtonDown("E") && inRange)
        {
            //MerchantTalk();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCanvas.alpha = 1;
        }
    }
}
