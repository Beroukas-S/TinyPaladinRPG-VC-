using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorEntryTest : MonoBehaviour
{
    public CanvasGroup playerCanvas;
    public bool inRange = false;
    public Transform exit;

    //placeholder interact button
    public Transform player;

    //blic delegate void InDoorRange(bool range);
    //blic static event InDoorRange OnInDoorRange;


    public Collider2D boundaryCollider;

    void Update()
    {
        //placeholder interact button
        if (Input.GetButtonDown("E") && inRange)
        {
            BuildingEnter();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCanvas.alpha = 1;
            inRange = true;
            //InDoorRange(inRange);

            //placeholder interact button
            //test = collision.transform;
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


    public void BuildingEnter()
    {
        boundaryCollider.enabled = true; 
        player.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        player.position = exit.position;
    }


}
