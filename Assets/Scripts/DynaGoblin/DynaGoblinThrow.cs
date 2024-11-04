using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynaGoblinThrow : MonoBehaviour
{

    public LayerMask playerLayer;
    public Transform attackPoint;
    public float attackRange;
    public GameObject dynamite;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Throw()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        if (hits.Length > 0)
        {
            GameObject dynamiteCreate = Instantiate(dynamite, attackPoint.position, Quaternion.identity);

            var MyScript = dynamiteCreate.GetComponent<SpriteRenderer>();
            MyScript.sortingOrder = 15;

        }
    }
}
