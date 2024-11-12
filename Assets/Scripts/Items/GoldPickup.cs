using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PickupGold : MonoBehaviour
{
    public float goldAmmount;
    public delegate void GoldPickup(float gold);
    public static event GoldPickup OnGoldPickup;
    private float timer;
    public float range1 = 91;
    public float range2 = 66;


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
        
        if (collision.gameObject.tag == "Player")
        {
            if (timer <= 0)
            {
                Destroy(gameObject);
                GoldAmount();
                OnGoldPickup(goldAmmount);
            }
        }
    }

    private void GoldAmount()
    {
        if (Random.Range(0f, 100f) >= range1)
        {
            goldAmmount = 10;
        }
        else if (Random.Range(0f, 1f) >= range2)
        {
            goldAmmount = 5;
        }
        else
        {
            goldAmmount = 2;
        }
    }
}
