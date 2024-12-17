using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour enemyMovement;
    [SerializeField] private bool disabledScript;

    
    public void EnableChase()
    {
        if (!disabledScript)
        {
            enemyMovement.Chase();
        }
    }

    public void EnableWander()
    {
        if (!disabledScript)
        {
            enemyMovement.Wander();
        }
    }

    
}
