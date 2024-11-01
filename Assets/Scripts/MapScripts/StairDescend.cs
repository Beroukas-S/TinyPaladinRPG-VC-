using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairDescend : MonoBehaviour
{
    public Collider2D stairsCollider;
    public Collider2D boundaryCollider;
    public StairClimb stairClimb;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        boundaryCollider.enabled = false;
        stairsCollider.enabled = true;


        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
            //stairClimb.counter--;
            //stairsCollider.enabled = true;

        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
            //stairClimb.counter--;
            //if (stairClimb.counter == 0) 
            //{
            //    stairsCollider.enabled = true;
            //}

            //collision.gameObject.GetComponentInChildren<Canvas>().sortingOrder = 4;
        }

        


    }
}
