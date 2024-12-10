using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;


    public void DeathSound(int nothing)
    {
        audioSource.Play();
    }
    private void OnEnable()
    {
        Enemy_Health.OnEnemyDefeated += DeathSound;
    }

    private void OnDisable()
    {
        Enemy_Health.OnEnemyDefeated -= DeathSound;
    }
}
