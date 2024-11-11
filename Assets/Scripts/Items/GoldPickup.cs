using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PickupGold : MonoBehaviour
{
    //public int goldAmmount = 5;
    //public delegate void GoldPickup(int gold);
    //public static event GoldPickup OnGoldPickup;
    private float timer;


    private void Start()
    {
        timer = 1;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //OnGoldPickup(goldAmmount);
        if (collision.gameObject.tag == "Player")
        {
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
