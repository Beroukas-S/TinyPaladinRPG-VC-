using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int faceDirection = 1;


    public Rigidbody2D rb;
    public Animator animat;
    public Grow growBig;
    public Player_Combat playerCombat;
    public MouseDirection mouseDirection;

    public Transform canvasTransform;
    public Transform projectileTransform;

    public bool isKnocked = false;


    private void Start()
    {
        mouseDirection = GetComponent<MouseDirection>();
    }


    void Update()
    {
        CheckBig();
        CheckQuickAttack();
        CheckHeavyAttack();
        mouseDirection.GetDirection();
    }

    // Update is called 50 per second
    void FixedUpdate()
    {
        if (isKnocked == false) 
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            animat.SetFloat("horizontal", Mathf.Abs(horizontal));
            animat.SetFloat("vertical", Mathf.Abs(vertical));
    
            rb.velocity = new Vector2(horizontal, vertical) * PlayerStats.Instance.speed;
    }

    }

    void Flip()
    {
        faceDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        canvasTransform.localScale = new Vector3 (canvasTransform.localScale.x * -1, canvasTransform.localScale.y, canvasTransform.localScale.z);
        projectileTransform.localScale = new Vector3(projectileTransform.localScale.x * -1, projectileTransform.localScale.y, projectileTransform.localScale.z);



    }

    public void KnockBack(Transform enemy,float knockBackForce,float duration)
    {
        isKnocked = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.velocity = direction * knockBackForce;
        StartCoroutine(KnockBackTime(duration));
    }

    IEnumerator KnockBackTime(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector2.zero;
        isKnocked = false;

    }

    public void CheckQuickAttack()
    {
        if (Input.GetMouseButtonDown(0) && mouseDirection.attackDirection == 3) //&& Input.GetAxis("Vertical") > 0)
        {
            playerCombat.QuickAttackUp();
        }
        else if (Input.GetMouseButtonDown(0) && mouseDirection.attackDirection == 4) // && Input.GetAxis("Vertical") < 0)
        {
            playerCombat.QuickAttackDown();
        }
        else if (Input.GetMouseButtonDown(0) && mouseDirection.attackDirection == 1)
        {
            if (faceDirection == -1)
            {
                Flip();
            }
            playerCombat.QuickAttack();
        }
        else if (Input.GetMouseButtonDown(0) && mouseDirection.attackDirection == 2)
        {
            if (faceDirection == 1) 
            {
                Flip();
            }
            playerCombat.QuickAttack();
        }
    }

    public void CheckHeavyAttack()
    {
        if (Input.GetMouseButtonDown(1) && mouseDirection.attackDirection == 3) //&& Input.GetAxis("Vertical") > 0)
        {
            playerCombat.HeavyAttackUp();
        }
        else if (Input.GetMouseButtonDown(1) && mouseDirection.attackDirection == 4) // && Input.GetAxis("Vertical") < 0)//
        {
            playerCombat.HeavyAttackDown();
        }
        else if (Input.GetMouseButtonDown(1) && mouseDirection.attackDirection == 1)
        {
            if (faceDirection == -1)
            {
                Flip();
            }
            playerCombat.HeavyAttack();
        }
        else if (Input.GetMouseButtonDown(1) && mouseDirection.attackDirection == 2)
        {
            if (faceDirection == 1)
            {
                Flip();
            }
            playerCombat.HeavyAttack();
        }
    }

    public void CheckBig()
    {
        if (Input.GetButtonDown("Jump"))
        {
            growBig.GrowBig();
        }
    }
    




}
