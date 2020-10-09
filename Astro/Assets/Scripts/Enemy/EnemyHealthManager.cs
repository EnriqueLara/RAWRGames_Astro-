using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;


    public void SetInitialHealth()
    {
        currentHealth = maxHealth;
    }

    public void SetHealth(float _health)
    {
        maxHealth = _health;
    }

    public void DamageEnemy(float _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    
}
