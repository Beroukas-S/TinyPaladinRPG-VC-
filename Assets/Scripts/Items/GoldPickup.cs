using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGold : MonoBehaviour
{
    public int goldAmmount = 5;
    public delegate void GoldPickup(int gold);
    public static event GoldPickup OnGoldPickup;


    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //OnGoldPickup(goldAmmount);
        Destroy(gameObject);
    }
}
