using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Sprite stuckArrow;
    [SerializeField] private Enemy enemy;
    private Rigidbody2D rb;
    public Transform playerTransform;
    public AudioSource audioSource;
    

    private Vector3 startingPlayerPosition;
    public LayerMask playerLayer;

    private float targetDistance;
    public float arrowSpeed;
    private bool hasHit = false;
    private bool isPlayer = false;
    [SerializeField] private float timeStuck;
    private float timer;
    public float knockBackForce;
    public float knockTime;
    



    // Start is called before the first frame update
    void Start()
    {
        //get direction to player
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector2 direction = (playerTransform.transform.position - transform.position).normalized;
        rb.velocity = direction * arrowSpeed;
        startingPlayerPosition = playerTransform.transform.position;

        //get correct rotation
        Vector3 rotation = startingPlayerPosition - transform.position;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        targetDistance = Vector3.Distance(startingPlayerPosition, transform.position);
        if (targetDistance <= 0.5f && !hasHit)
        {
            isPlayer = false;
            HitSomething(isPlayer);
        }
        if (isPlayer)
        { 
            timer -= Time.deltaTime;
        }
        if (hasHit && timer <= 0)
        {
            DestroyArrow();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasHit)
        {
            HitPlayer(collision);
        }
    }

    private void HitSomething(bool isPlayer)
    {
        rb.velocity = Vector2.zero;
        HitSound();
        StickArrow(isPlayer);
        hasHit = true;
    }


    public void DestroyArrow()
    {
        Destroy(gameObject);
    }

    public void HitSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void HitPlayer(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthMono>().ChangeHP(-enemy.attackDamage);
            if (player.currentHP > 0)
            {
                collision.gameObject.GetComponent<PlayerMovement>().KnockBack(transform, knockBackForce, knockTime);
            }
            isPlayer = true;
            HitSomething(isPlayer);
            transform.SetParent(collision.transform);

        }
    }

    public void StickArrow(bool isPlayer)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = stuckArrow;
        if (!isPlayer)
        {
            transform.rotation = Quaternion.Euler(0, 0, -35f);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
        timer = timeStuck;
        
    }


}
