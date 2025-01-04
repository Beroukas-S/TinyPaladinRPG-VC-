using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    private Rigidbody2D rb;
    public Animator animator;
    public Transform playerTransform;
    public AudioSource audioSource;

    private Vector3 startingPlayerPosition;
    public LayerMask playerLayer;

    private float playerDistance;
    public float dynamiteSpeed;
    public float timer;
    public float knockBackForce;
    public float knockTime;
    public float explosionRange;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector2 direction = (playerTransform.transform.position - transform.position).normalized;
        rb.velocity = direction * dynamiteSpeed;
        startingPlayerPosition = playerTransform.transform.position;
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
        BlowSound();
    }

    
    public void DestroyDynamite()
    { 
        Destroy(gameObject);
    }

    public void BlowSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void Damage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRange, playerLayer);
        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealthMono>().ChangeHP(-enemy.attackDamage);
            if (player.currentHP > 0)
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
