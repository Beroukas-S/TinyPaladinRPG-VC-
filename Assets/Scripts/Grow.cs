using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    bool big = false;
    float duration = 0.08f;

    // Update is called once per frame

    public void GrowBig()
    {
        //growing
        if (big == false)
        {
            StartCoroutine(Transformation(duration, big));
            big = true;
        }
        else
        {
            StartCoroutine(Transformation(duration, big));
            big = false;
        }
    }

    //sprite wiggle
    IEnumerator Transformation(float duration, bool size)
    {
        if (size)
        {
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(duration);
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(duration);
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(duration);
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(duration);
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(duration);
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(duration);
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(duration);
            transform.localScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
            yield return new WaitForSecondsRealtime(duration);
            transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z);
        }
 

    }




}
