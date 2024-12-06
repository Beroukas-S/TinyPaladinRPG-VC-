using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantSpeech : MonoBehaviour
{
    [SerializeField] private CanvasGroup messageCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            messageCanvas.alpha = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            messageCanvas.alpha = 0;
        }
    }

}
