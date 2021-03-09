using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int startHealth = 2;

 
    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = startHealth;

    }

    public void TakeDamage(int damage)
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
