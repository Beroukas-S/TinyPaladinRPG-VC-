using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    public Transform player;

    private Vector3 startingPlayerPosition;
    public LayerMask playerLayer;

    private float playerDistance;
    public float dynamiteSpeed;
    public float timer;
    public int damage;
    public float knockBackForce;
    public float knockTime;
    public float explosionRange;



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

    public void Damage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRange, playerLayer);
        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().ChangeHP(-damage);
            if (PlayerStats.Instance.currentHP > 0)
            {
                hits[0].GetComponent<PlayerMovement>().KnockBack(transform, knockBackForce, knockTime);
            }

        }
    }

    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
    */
}
