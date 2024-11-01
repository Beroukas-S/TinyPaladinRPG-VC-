using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairClimb : MonoBehaviour
{
    public Collider2D stairsCollider;
    public Collider2D boundaryCollider;

    //public int counter;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        stairsCollider.enabled = false;
        boundaryCollider.enabled = true;
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
            //counter++;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
            //counter++;
            //collision.gameObject.GetComponentInChildren<Canvas>().sortingOrder = 15;
        }
    }

    


}
