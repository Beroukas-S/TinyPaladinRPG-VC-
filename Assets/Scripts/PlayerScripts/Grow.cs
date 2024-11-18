using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    private bool big = false;
    private float wiggle = 0.08f;
    private float duration = 10;
    public float timer;


    // Update is called once per frame

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <=0 && big == true)
        {
            GrowBig();
        }
    }

    public void GrowBig()
    {
        //growing
        if (big == false)
        {
            StartCoroutine(Transformation(wiggle, big));
            big = true;
            timer = duration;

        }
        else
        {
            StartCoroutine(Transformation(wiggle, big));
            big = false;
        }
    }

    //sprite wiggle
    IEnumerator Transformation(float wiggle, bool size)
    {
        if (size)
        {
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(wiggle);
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(wiggle);
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(wiggle);
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(wiggle);
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(wiggle);
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(wiggle);
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(wiggle);
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(wiggle);
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
        }
 

    }

    public void Meat()
    {
        if (big == false)
        {
            GrowBig();
        }
        else
        {
            timer = duration;
        }
    }


    private void OnEnable()
    {
        PickupMeat.OnMeatPickup += Meat;
    }

    private void OnDisable()
    {
        PickupMeat.OnMeatPickup -= Meat;
    }


}
