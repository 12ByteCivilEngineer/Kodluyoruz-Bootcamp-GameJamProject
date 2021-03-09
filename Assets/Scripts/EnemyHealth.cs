using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float startHealth = 2;

 
    private float currentHealth;

    private void OnEnable()
    {
        currentHealth = startHealth;

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        gameObject.SetActive(false);

    }
    
}
