using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dynamiteSpeed;
    public Animator animator;
    public Transform player;
    private Vector3 startingPlayerPosition;
    private float playerDistance;
    public float timer = 2;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * dynamiteSpeed;
        startingPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(startingPlayerPosition, transform.position);
        if (playerDistance <= 1)
        {
            //timer = 2;
            rb.velocity = Vector2.zero;
            //if (timer > 0)
            //{
            //    timer -= Time.deltaTime;
            //}
            //else
            //{
            //    rb.velocity = Vector2.zero;
            //    animator.SetBool("isBoom", true);
            //}
            StartCoroutine(Fuse(timer));

        }
    }

    IEnumerator Fuse(float time)
    { 
        yield return new WaitForSeconds(time);
        animator.SetBool("isBoom", true);
    }

    

    public void DestroyDynamite()
    { 
        Destroy(gameObject);
    }
}
