using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnTest : MonoBehaviour
{
    public GameObject spawnEnemy;
    public float spawnTime;
    public Transform player;
    public int spawnRange;


    private float timer = 0;
    //private Vector3 spawnPosition = transform.position;

    public void Update()
    {
        if (Vector2.Distance(transform.position, player.position) <= spawnRange)
        {
            if (timer <= 0)
            {
                GameObject newEnemy = Instantiate(spawnEnemy, transform.position, Quaternion.identity);
                timer = spawnTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

  //  private void OnDrawGizmosSelected()
  //  {
  //      Gizmos.color = Color.red;
  //      Gizmos.DrawWireSphere(transform.position, spawnRange);
  //  }


}
