using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExit : MonoBehaviour
{
    public CanvasGroup playerCanvas;
    public bool inRange = true;
    public Transform entrance;

    public Transform player;

    public Collider2D boundaryCollider;

    void Update()
    {
        if (Input.GetButtonDown("E") && inRange)
        {
            BuildingExit();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.gameObject.GetComponent<SpriteRenderer>().sortingOrder == 15)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerCanvas.alpha = 1;
                inRange = true;

            }
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


    public void BuildingExit()
    {
        if (player.gameObject.GetComponent<SpriteRenderer>().sortingOrder == 15)
        {
            boundaryCollider.enabled = false;
            player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
            player.position = entrance.position;
        }
    }
}
