using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMeat : MonoBehaviour
{
    public delegate void MeatPickup();
    public static event MeatPickup OnMeatPickup;




    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnMeatPickup();
        Destroy(gameObject);
    }
}
