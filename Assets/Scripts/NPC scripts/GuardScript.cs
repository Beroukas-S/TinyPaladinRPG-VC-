using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuardScript : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private CanvasGroup guardCanvas;
    [SerializeField] private bool messageShown;
    [SerializeField] private float messageFade = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!messageShown)
            {
                guardCanvas.alpha = 1;
            }
            StartCoroutine(FadeTime(messageFade));
        }
    }

    IEnumerator FadeTime(float time)
    {
        yield return new WaitForSeconds(time);
        guardCanvas.alpha = 0;
        messageShown = true;
    }
}
