using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    //keeps track if it is a forestroke or backstroke
    public bool secondAttack = false;

    public PlayerBlock block;

    public PlayerState playerState;


    private void Start()
    {
        mouseDirection = GetComponent<MouseDirection>();
        ChangeState(PlayerState.Idle);
    }


    void Update()
    {
        CheckBig();
        mouseDirection.GetDirection();
        CheckAttack();
        CheckBlock();
    }

    // fixedUpdate is called 50 per second
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
            if (rb.velocity != Vector2.zero)
            {
                ChangeState(PlayerState.Moving);
            }
            else if (playerState != PlayerState.Attacking)
            {
                ChangeState(PlayerState.Idle);
            }
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
        ChangeState(PlayerState.KnockedBack);
        block.BlockEnd();
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.velocity = direction * knockBackForce;
        StartCoroutine(KnockBackTime(duration));
        
    }

    IEnumerator KnockBackTime(float time)
    {
        yield return new WaitForSeconds(time);
        rb.velocity = Vector2.zero;
        isKnocked = false;
        ChangeState(PlayerState.Idle);

    }

    //calls different method for backstroke or forestroke
    //Quick attack = forehand, heavy attack = backhand
    public void CheckAttack()
    {
        if (!secondAttack && Input.GetMouseButtonDown(0))
        {
            CheckQuickAttack();
            block.BlockEnd();
            ChangeState(PlayerState.Attacking);
        }
        else if (secondAttack && Input.GetMouseButtonDown(0))
        { 
            CheckHeavyAttack();
            block.BlockEnd();
            ChangeState(PlayerState.Attacking);
        }
    }

    //changes the stroke
    public void ChangeAttackAnim()
    {
        if (!secondAttack)
        {
            secondAttack = true;
        }
        else
        { 
            secondAttack= false;
        }
    }

    public void CheckQuickAttack()
    {
        if (mouseDirection.attackDirection == 3) 
        {
            playerCombat.QuickAttackUp();
        }
        else if (mouseDirection.attackDirection == 4) 
        {
            playerCombat.QuickAttackDown();
        }
        else if (mouseDirection.attackDirection == 1)
        {
            if (faceDirection == -1)
            {
                Flip();
            }
            playerCombat.QuickAttack();
        }
        else if (mouseDirection.attackDirection == 2)
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
        if (mouseDirection.attackDirection == 3) 
        {
            playerCombat.HeavyAttackUp();
        }
        else if (mouseDirection.attackDirection == 4) 
        {
            playerCombat.HeavyAttackDown();
        }
        else if (mouseDirection.attackDirection == 1)
        {
            if (faceDirection == -1)
            {
                Flip();
            }
            playerCombat.HeavyAttack();
        }
        else if (mouseDirection.attackDirection == 2)
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

    public void CheckBlock()
    {
        if (Input.GetMouseButton(1) && playerState != PlayerState.Attacking && playerState != PlayerState.KnockedBack)
        {
            block.Block();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            block.BlockEnd();      
        }
    }

    public void ChangeState(PlayerState newState)
    {
        playerState = newState;
    }

}

public enum PlayerState
{ 
    Idle,
    Moving,
    KnockedBack,
    Attacking,
    Blocking,
}
