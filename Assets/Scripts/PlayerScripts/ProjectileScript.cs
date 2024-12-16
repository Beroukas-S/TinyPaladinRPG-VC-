using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private Player player;
    private Camera cam;
    private Vector3 mousePos;
    private Rigidbody2D rb;
    public float projectileSpeed;
    public Animator animator;
    public AudioSource audioSource;

    public float travelDistanceLimit;

    private float travelDistance;
    private Vector3 startinPosition;


    private void Start()
    {
        //transform position is the position of the object in shooting script
        animator.SetBool("onHit", false);
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * projectileSpeed;

        //correct fireball rotation based on aim
        Vector3 rotation = mousePos - transform.position;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        startinPosition = transform.position;

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
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy_Health>().ChangeHP(-player.fireballDamage);
            rb.velocity = Vector2.zero;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = collision.transform.position;
            //transform.position = (collision.transform.position - transform.position).normalized;
            animator.SetBool("onHit", true);
            audioSource.Play();
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
