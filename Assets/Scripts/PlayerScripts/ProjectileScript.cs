using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private EnemyBoss boss;
    private Camera cam;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float projectileSpeed;
    public Animator animator;
    public AudioSource audioSource;

    public float travelDistanceLimit;
    public Transform playerTransform;
    private PlayerBlock playerBlock;

    private float travelDistance;
    private Vector3 startinPosition;
    bool createdByPlayer;

    public void Initialize(bool _createdByPlayer)
    {
        createdByPlayer = _createdByPlayer;
    }

    private void Start()
    {
        //transform position is the position of the object in shooting script
        animator.SetBool("onHit", false);
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        if (createdByPlayer == true)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 direction = mousePos - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * projectileSpeed;

            //correct fireball rotation based on aim
            Vector3 rotation = mousePos - transform.position;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
            startinPosition = transform.position;
        }
        else
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 direction = playerTransform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * projectileSpeed;

            //correct fireball rotation based on player position
            Vector3 rotation = playerTransform.position - transform.position;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
            startinPosition = transform.position;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //για να μην πετάει για πάντα
        travelDistance = Vector3.Distance(startinPosition, transform.position);
        if (travelDistance > travelDistanceLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (createdByPlayer)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (collision.gameObject.GetComponent<Enemy_Health>() != null)
                {
                    collision.gameObject.GetComponent<Enemy_Health>().ChangeHP(-player.fireballDamage);
                }
                if (collision.gameObject.GetComponent<BossHealth>() != null)
                {
                    collision.gameObject.GetComponent<BossHealth>().ChangeHP(-player.fireballDamage);
                }
                rb.velocity = Vector2.zero;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = collision.transform.position;
                //transform.position = (collision.transform.position - transform.position).normalized;
                animator.SetBool("onHit", true);
                audioSource.Play();
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealthMono>().ChangeHP(-boss.projectileDamage);

                rb.velocity = Vector2.zero;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.position = collision.transform.position;
                //transform.position = (collision.transform.position - transform.position).normalized;
                PlayerBlock block = collision.gameObject.GetComponentInChildren<PlayerBlock>();
                animator.SetBool("onHit", true);
                audioSource.Play();
                block.BlockEnd();
            }
        }
        /* Να το φτιάξω με νέο layer ωστε το detection να γίνεται σε καλύτερο σημείο
        else if (collision.gameObject.tag == "Terrain")
        {
            rb.velocity = Vector2.zero;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("onHit", true);
            transform.position = collision.transform.position;
        }
        */
    }

    //called at the end of explosion animation
    public void DestroyFireball()
    {
        Destroy(gameObject);
    }


}
